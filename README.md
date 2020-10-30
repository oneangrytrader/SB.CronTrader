Automated backtesting algorithm as a rule interpreter

This C# script will ask for 3 parameters:

| Parameter |   Definition                     |
|-----------|----------------------------------|
| -r        |  Json file with rules            |
| -d        |  Csv data file in candle format  |
| -e        |  Market epic identifier          |

Check the sample rules folder for sample techniques

The program will iterate through every candle executing the rules provided

<table class="table table-striped table-responsive-md btn-table">
        <thead>
            <tr>
                <th>#</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Username</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">1</th>
                <td>
                    <button type="button" class="btn btn-indigo btn-sm m-0">Button</button>
                </td>
                <td>Otto</td>
                <td>@mdo</td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>Jacob</td>
                <td>
                    <button type="button" class="btn btn-indigo btn-sm m-0">Button</button>
                </td>
                <td>@fat</td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>Larry</td>
                <td>the Bird</td>
                <td>
                    <button type="button" class="btn btn-indigo btn-sm m-0">Button</button>
                </td>
            </tr>
        </tbody>

    </table>