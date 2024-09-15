//$(document).ready(function () {
//    $('#categoryDiv').hide();
//    $('#divLaptops').hide();
//    $('#SubmitID').hide();

//    $('#ManufacturersID').change(function () {
//        var URL = 'home/CategoryList/' + $('#ManufacturersID').val();
//        $.getJSON(URL, function (data) {
//            var items = '<option value="">Select Category</option>';
//            $.each(data, function (i, category) {
//                items += "<option value='" + category.Value + "'>" + category.Text + "</option>";
//            });
//            $('#CategoryID').html(items);
//            $('#categoryDiv').show();
//        });
//    });
//});
$(document).ready(function () {
    $('#categoryDiv').hide();
    $('#divLaptops').hide();
    $('#SubmitID').hide();

    $('#ManufacturersID').change(function () {
        var URL = 'home/CategoryList/' + $('#ManufacturersID').val();
        console.log(URL);
        $.getJSON(URL, function (data) {
            var items = '<option value="">Select Category</option>';
            $.each(data, function (i, category) {
                items += "<option value='" + category.Value + "'>" + category.Text + "</option>";
            });
            $('#CategoryID').html(items);
            $('#categoryDiv').show();
        });
    });

    $('#CategoryID').change(function () {
        var category = $('#CategoryID option:selected').text();
        var URL = 'home/GetLaptops?category=' + category;

        $.ajax({
            url: URL,
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html'

        })
            .success(function (result) {
                $('#divLaptops').show();
                $('#divLaptops').html(result);
            })
            .error(function (xhr, status) {
                alert(status);
            })

        $('#SubmitID').show();
    });
});