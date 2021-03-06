Automated backtesting algorithm as a rule interpreter

This C# script will ask for 3 parameters:

| Parameter |   Definition                     |
|-----------|----------------------------------|
| -r        |  Json file with rules            |
| -d        |  Csv data file in candle format  |
| -e        |  Market epic identifier          |

Check the sample rules folder for sample techniques

The program will iterate through every candle executing the rules provided

Uppercase texts are static values coming from enums and must be specified exactly like they are indicated.

<table>
    <thead>
            <tr>
                <th>Parameter</th>
                <th>Type</th>
                <th>Value</th>
                <th>Definition</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td rowspan="2">RuleType</td>
                <td>Enum</td>
                <td>ENTRY</td>
                <td>Open a Position</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>UPDATE</td>
                <td>Update a Position</td>
            </tr>
            <tr>
                <td rowspan="2">Frequency</td>
                <td>Enum</td>
                <td>SINGLE</td>
                <td>Execute the rule just once</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>MULTIPLE</td>
                <td>Execute the rule on every candle that matches the rule</td>
            </tr>
            <tr>
                <td rowspan="2">Direction</td>
                <td>Enum</td>
                <td>BUY</td>
                <td>Long Position</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>SELL</td>
                <td>Short Position</td>
            </tr>
            <tr>
                <td rowspan="2">Strategy</td>
                <td>Enum</td>
                <td>ENTRY_AT_LEVEL</td>
                <td>Open the position setting stop and limit levels</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>ENTRY_AT_DATE</td>
                <td>Open the position setting stop and limit levels at a specific date</td>
            </tr>
            <tr>
                <td rowspan="3">PositionStatus</td>
                <td>Enum</td>
                <td>OPEN</td>
                <td>First status when the position is opened</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>LIMIT_REACHED</td>
                <td>Limit level has been reached</td>
            </tr>
            <tr>
                <td>Enum</td>
                <td>STOP_REACHED</td>
                <td>Stop level has been reached</td>
            </tr>
            <tr>                
                <td>Level</td>
                <td>Double</td>
                <td>Number</td>
                <td>If set it will enter only at specific value or better.<br/>
                    If not set it will enter at market level.
                </td>
            </tr>
            <tr>                
                <td>Spread</td>
                <td>Double</td>
                <td>Number</td>
                <td>Spread applied by the broker</td>
            </tr>
            <tr>                
                <td>Stop</td>
                <td>Double</td>
                <td>Points away from level</td>
                <td>Level to stop and exit the position</td>
            </tr>            
            <tr>                
                <td>Limit</td>
                <td>Double</td>
                <td>Points away from level</td>
                <td>Level to exit the position and take profit</td>
            </tr>            
        </tbody>
    </table>