//google.charts.load('current', { 'packages': ['corechart'] });
//google.charts.setOnLoadCallback(drawChart);

//function drawChart() {
    
//    var present = 0;
//    var absent = 0;
    
//    foreach(var item in tableRows)
//    {
//        if (item == "Yes") {
//            present++;
//        }
//        else {
//            absent++;
//        }
//    }


//    var data = google.visualization.arrayToDataTable([
//        ['Task', 'Hours per Day'],
//        ['Present', present],
//        ['Absent', absent]
//    ]);

//    var options = {
//        title: 'Employee Attendance Pi-Chart'
//    };

//    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

//    chart.draw(data, options);
//}