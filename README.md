Automated backtesting algorithm as a rule interpreter

This C# script will ask for 3 parameters:

| Parameter |   Definition                     |
|-----------|----------------------------------|
| -r        |  Json file with rules            |
| -d        |  Csv data file in candle format  |
| -e        |  Market epic identifier          |

Check the sample rules folder for sample techniques

The program will iterate through every candle executing the rules provided

<table style="width:800px;text-align:left;" border="1">
    <thead>
        <tr>
            <th>Parameter</th><th>Value</th><th>Definition</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td rowspan="2">RuleType</td><td>ENTRY</td><td>Open a Position</td>
        </tr>
        <tr>
            <td>UPDATE</td><td>Update a Position</td>
        </tr>
        <tr>
            <td rowspan="2">Frequency</td><td>SINGLE</td><td>Execute the rule just once</td>
        </tr>
        <tr>
            <td>MULTIPLE</td><td>Execute the rule on every candle that matches the rule</td>
        </tr>
        <tr>
            <td rowspan="2">Direction</td><td>BUY</td><td>Long Position</td>
        </tr>
        <tr>
            <td>SELL</td><td>Short Position</td>
        </tr>
        <tr>
            <td rowspan="2">Strategy</td><td>ENTRY_AT_LEVEL</td><td>Open the position at market level setting stop and limit levels</td>
        </tr>
        <tr>
            <td>ENTRY_AT_DATE</td><td>Open the position at market level setting stop and limit levels at a specific date</td>
        </tr>
    </tbody>
</table>