# warm-up-test
Simple http status and selenium tests to run on slot from json with schema as below.
The Json file is selected in `Theory.cs` in the attribute `[JsonFileData("data.json")]`
The `BaseUrl` is passed in as an environment variable in `Fixture.cs` (which is currently done from `LaunchSettings.json`)

```Json
{
  "tests": [
    {
      "name": "Shop page should contain a H1",
      "type": "XPath",
      "path": "/",
      "expression": "//h1[contains(text(), 'Shop')]",
      "expectation": true
    },
    {
      "name": "Shop page should not contain a H4",
      "type": "XPath",
      "path": "/",
      "expression": "//h4",
      "expectation": false
    },
    {
      "name": "Shop page should report a 200",
      "type": "HttpStatusCode",
      "path": "/",
      "expectation": 200
    },
    {
      "name": "Pages that do not exist report a 404",
      "type": "HttpStatusCode",
      "path": "/not-a-page",
      "expectation": 404
    },
    {
      "name": "Should redirect to login for secure page",
      "type": "HttpStatusCode",
      "path": "/checkout",
      "expectation": 302
    },
    {
      "name": "Login button should exist",
      "type": "CssSelector",
      "path": "/",
      "expression": "a[aria-label='Login/sign up']",
      "expectation": true
    }
  ]
  ```
