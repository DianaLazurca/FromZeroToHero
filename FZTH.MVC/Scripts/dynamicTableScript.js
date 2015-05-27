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

// create a new hotel 
//$('#create').click(function () {

//    console.log("click pe create hotel");
//    var tr = $('<tr></tr>');
//    var inputs = $('<td><input type = "text"></td>');
//    tr.append(inputs);
//    tr.append($('<td><input type = "text"></td>'));
//    tr.append($('<td><input type = "text"></td>'));
//    tr.append($('<td><input type = "text"></td>'));
//    $('#hotelsContainer').append(tr);
//    console.log(tr.children());
    
//});

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

    $('#hotelsContainer').on('click', 'a[data-id]', function () {
        // alert("delete clicked");
        var hotelId = $(this).attr("data-id");
        console.log(hotelId);
        
        var tr = $('table tr[id = ' + parseInt(hotelId) + ']');
        //console.log(tr);
        tr.children().each(function (index) {
            
            if (index < 8) {
                var t = $(this).text();
                $(this).html($('<input/>', { 'value': t }).val(t));
            }

            if (index == 8) {
                var count = $(this).find("img");
                $(this).html($('<input/>', { 'value': count.length }).val(count.length));
            }
            if (index == 9) {
                tr.children().last().children().remove();
                tr.children().last().append($('<a target="_self" href="#hotelContainer" id="confirm'+ hotelId+'" > Confirm </a> | <a href="#hotelContainer" target="_self" id= "cancel"> Cancel </a>'))

            }
            
        });
    });

    $('#hotelsContainer').on('click', 'a[id ^="confirm"]', function () {
        alert("confirm pressed");
        var hotelId = $(this).attr("id").split("confirm")[1];
        var tr = $('table tr[id = ' + parseInt(hotelId) + ']');
        console.log(tr);
        var hotel = new Array();
        hotel.push(hotelId);
        
        tr.children().each(function (index) {

            if (index < 9) {
                hotel.push($(this).find('input').val());
            }

            
           /* if (index == 9) {
                tr.children().last().children().remove();
                tr.children().last().append($('<a target="_self" href="#hotelContainer" id="confirm' + hotelId + '" > Confirm </a> | <a href="#hotelContainer" target="_self" id= "cancel"> Cancel </a>'))

            }*/

        });
      //  console.log(hotel);
        $.ajax({
            method: "POST",
            url: "http://localhost/booking/Hotel/Edit/",
            dataType: 'application/json',
            data: {
                    Id: parseInt(hotelId),
                    Name: hotel.shift(),
                    Description: hotel.shift(),
                    Address: hotel.shift(),
                    City: { Name : hotel.shift(), County : hotel.shift()},
                    DistanceToCenter: hotel.shift(),
                    OpeningDate: hotel.shift(),
                    RoomNr: hotel.shift(),
                    Stars: hotel.shift()

            },

            success: function (data) {
                tr.children().each(function (index) {

                    if (index < 8) {
                        $(this).text($(this).find('input').val());
                    }

                    if (index == 8) {
                        var count = $(this).find("input").val();
                        console.log(count);
                    }
                    if (index == 9) {
                        tr.children().last().children().remove();
                        tr.children().last().append($('<a target="_self" href="#hotelContainer" id="confirm' + hotelId + '" > Confirm </a> | <a href="#hotelContainer" target="_self" id= "cancel"> Cancel </a>'))

                    }

                });
            }

        });
    });



