$(document)
    .ready(function () {
        var ctx = $('#grafico')
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: meses,
                datasets: [{
                    label: 'Proposta',
                    backgroundColor: '#8B0000',
                    borderColor: '#ff3030',
                    data: Prop,
                },
                {
                    label: 'Realizado',
                    backgroundColor: '#6495ED',
                    borderColor: '#000080',
                    data: Reali
                }]
            },
            options: {
                scales: {
                    yAxes: {
                        tickes: {
                            beginAtZero: true
                        }
                    }
                }
            }
        });
    });

$(document)
    .ready(function () {
        var ctx = $('#novoGrafico')
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: meses,
                datasets: [{
                    label: 'Proposta',
                    backgroundColor:
                            '#6495ED',
                    borderColor: '#000000',
                    data: Prop,
                },
                {
                    label: 'Realizado',
                    backgroundColor:
                            '#000080',
                    borderColor: 'rgb(13, 99, 132)',
                    data: Reali
                }]
            },
            options: {
                scales: {
                    yAxes: {
                        tickes: {
                            beginAtZero: true
                        }
                    }
                }
            }
        });
    });