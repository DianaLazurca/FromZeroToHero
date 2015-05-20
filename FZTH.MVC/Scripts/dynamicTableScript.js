function generateHotelView(array) {
    var container = $('#hotelsContainer');
    var table = $('<table/>', { 'class': 'table table-striped' });
    // container.append(table);

    var tr = $('<tr></tr>');
    var th = $('<th > Name </th>');
    tr.append(th);
    th = $('<th> Description </th>');
    tr.append(th);
    th = $('<th> Address </th>');
    tr.append(th);
    th = $('<th> City </th>');
    tr.append(th);
    th = $('<th> County </th>');
    tr.append(th);
    th = $('<th> Km to Center </th>');
    tr.append(th);
    th = $('<th> Opening Date </th>');
    tr.append(th);
    th = $('<th> Rooms </th>');
    tr.append(th);
    th = $('<th> Stars </th>');
    tr.append(th);
    th = $('<th> Operations </th>');
    tr.append(th);
    table.append(tr);

    $.each(array, function () {
        var newRow = $('<tr id = ' + this.Id + '></tr>');

        var col = $('<td>' + this.Name + '</td>');
        newRow.append(col);
        col = $('<td>' + this.Description + '</td>');
        newRow.append(col);
        col = $('<td>' + this.Address + '</td>');
        newRow.append(col);
        col = $('<td>' + this.City.Name + '</td>');
        newRow.append(col);
        col = $('<td>' + this.City.County.Name + '</td>');
        newRow.append(col);
        col = $('<td>' + this.DistanceToCenter + '</td>');
        newRow.append(col);
        col = $('<td>' + new Date(parseInt(this.OpeningDate.split("(")[1].split(")")[0])).toLocaleString() + '</td>');
        newRow.append(col);
        col = $('<td>' + this.RoomNr + '</td>');
        newRow.append(col);
        col = $('<td></td>');
        for (var i = 0; i < parseInt(this.Stars) ; i++) {
            col.append($('<img src="http://localhost/booking/images/star.gif" alt=\"Noo star for you\" height=20 width=20 />'))
        }

        newRow.append(col);
        col = $('<td> <a target="_self" href="#hotelContainer" data-id= '+this.Id+'> Edit </a> | <a href="#hotelContainer" target="_self" id=' + "delete" + this.Id + '> Delete </a></td>');
        newRow.append(col);

        table.append(newRow);

    });

    container.append(table);

}

    $.ajax({
        method: "GET",
        // url: '@Url.Action("HotelsJS", "Hotel")',
        url:"http://localhost/booking/Hotel/HotelsJS",
        success: function (data) {
            console.log(data);
            generateHotelView(data);

           // console.log($('#hotelsContainer  a[id ^= delete]'));


        },
        error: function (data) {
            console.log("Error happened");
        }
    });



    $('#hotelsContainer').on('click', 'a[id ^= delete]', function () {
       // alert("delete clicked");
        var hotelId = $(this).attr("id").split("delete")[1];
        console.log(hotelId);
        var r = confirm("Are you sure you want to delete this hotel?");
        if (r == true) {
            $.ajax({
                method: "POST",
                url: "http://localhost/booking/Hotel/Delete/",
                data: { id: parseInt(hotelId) },
               
                success : function(){
                    $('#hotelsContainer table tr[id=' + hotelId + ']').remove();
                }

            });
        }
    });




