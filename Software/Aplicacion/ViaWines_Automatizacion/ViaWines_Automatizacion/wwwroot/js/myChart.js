function getChartData() {
    $("#loadingMessage").html('<img src="./giphy.gif" alt="" srcset="">');


    var datos = {
            "labels": [
                "sunday",
                "monday",
                "tuesday",
                "wednesday",
                "thursday",
                "friday",
                "saturday"
            ],
            "Botellas": [
                20000,
                14000,
                12000,
                15000,
                18000,
                19000,
                22000
            ],
            "Cajas": [
                19000,
                10000,
                14000,
                14000,
                15000,
                22000,
                24000
            ]
        
    }

    $("#loadingMessage").html("");
    var data = [];
    data.push(datos.Botellas);
    data.push(datos.Cajas);
    var labels = datos.labels;
    renderChart(data, labels);


    /*$.ajax({
        url: "http://localhost:3000/chartdata",
        success: function (result) {
            $("#loadingMessage").html("");
            var data = [];
            data.push(datos.Botellas);
            data.push(datos.Cajas);
            var labels = datos.labels;
            renderChart(data, labels);
        },
        error: function (err) {
            $("#loadingMessage").html("Error");
        }
    });*/
}



function renderChart(data, labels) {
    var ctx = document.getElementById("myChart").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Botellas',
                    data: data[0],
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                },
                {
                    label: 'Cajas',
                    data: data[1],
                    borderColor: 'rgba(192, 192, 192, 1)',
                    backgroundColor: 'rgba(192, 192, 192, 0.2)',
                }
            ]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        
                        beginAtZero: true
                        /*callback: function (value, index, values) {
                            return float2dollar(value);
                        }*/
                    }
                }]
            },
        }
    });
}