namespace Asdf.Profile.Api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Asdf.Profile.Api

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet>]
    member __.Get() : WeatherForecast[] =
        let rng = System.Random()
        [|
            for index in 0..4 ->
                {
                  Date = DateTime.Now.AddDays(float index)
                  TemperatureC = rng.Next(-20,55)
                  Summary = summaries.[rng.Next(summaries.Length)]
                }
        |]

    
    let discounter (mailbox: Actor<_>) =
        let rec loop () = actor {
            let! CalculatedDiscountPriceFor(requester, retailerId, rfqId, itemId) = mailbox.Receive ()
            printfn "Discounter: CalculatedDiscountPriceFor received" 
            mailbox.Sender () <! DiscountPriceCalculated(requester, retailerId, rfqId, itemId, 100m, 89.99m)
            return! loop ()
        }
        loop ()

    let requester quotes (mailbox: Actor<_>) =
        let rec loop () = actor {
            let! PriceQuote(_, _, _, _,retailPrice, discountPrice) = mailbox.Receive ()
            printfn "Requester: PriceQuote received, retailPrice: %M, discountPrice %M" retailPrice discountPrice 
            return! loop ()
        }
        quotes <! RequestPriceQuote("retailer1", "rfq1", "item1")
        loop ()