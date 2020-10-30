Automated backtesting algorithm as a rule interpreter

This C# script will ask for 3 parameters:

| Parameter|   Definition                     |
|----------|----------------------------------|
| -r       |  Json file with rules            |
| -d       |  Csv data file in candle format  |
| -e       |  Market epic identifier          |

The program will iterate through every candle executing the rules provides

| Rule Type|   Definition        |
|----------|---------------------|
| ENTRY    |  Open a position    |
| UPDATE   |  Update a position  |
