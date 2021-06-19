## Example Request
```
{
    "fromPrice": {
        "currency": {
            "currencyIso": "GBP"
        },
        "amount": 12.434
    },
    "targetCurrencyIso": {
       "currencyIso": "EUR"
    }
}
```

## TODO

The solution is functional but there are quite a few things that I would like to tidy up:

 - More unit testing including:
   - More scenarios
   - Tests that cover a larger scope (E.G. entering at the controller, mocking the JSON file rather than the service)
   - Better mocking of prices
   - Use of test case source 
 - Better validation and error handling
   - Haven't set up a destination for the error logs or an Exception Filter
   - If something goes wrong the api consumer is going to get a generic 500 most of the time. The argument exceptions should be handled as 400 status code as they would be user error in this case.
     - More data annotaions would be the first thing to do here.
   - I made up the logic on Currency ISOs being 3 chars so that needs checking and should present as a 400 error if an invalid format is provided.
 - Request format
   - The request format is not very friendly. I was really going for:
```
{
  "fromPrice": {
    "currency": "GBP",
    "amount": 5
  },
  "targetCurrency": "EUR"
}
```
   - I should have just created separate request objects but I was trying to avoid needing mapping extra code.
   - Swagger is not showing an accurate example which will make it hard to test. The documentation works differently from .Net Standard so I didn't manage to override the example.
 - Authentication
   - Neither of these services uses authentication. Depending how they were hosted this could leave them open to abuse.
 - Domain
   - Currency and Price constructors are a little verbose. Adding an implicit string -> currency converter would help.
