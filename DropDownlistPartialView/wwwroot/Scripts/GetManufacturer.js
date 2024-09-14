$(document).ready(function () {
    var URL = 'home/ManufacturerList';
    console.log(URL);
    $.getJSON(URL,function (data) {
            console.log(data);
        var items = '<option value="">--Select Manufacturer--</option>';
        $.each(data,function(i, manufacturer) {
            console.log(i);
            items += "<option value='" + manufacturer.Value + "'>" + manufacturer.Text
                + "</option>";
        });
        $('#ManufacturersID').html(items);
    });
});