$(document).ready(function () {
    GetProducts();

});

//Read Data
function GetProducts() {
    $.ajax({
        url: 'Product/GetProducts',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response)
        {
            console.log('abcd');
            if (response == null || response == undefined || response.length == 0)
            {
                var object = '';
                object += '<tr>';
                object += '<td colspan="5">' + 'Product is not available' + '</td>';
                object += '</tr>';
                $('#tblBody').html(object);
            }
            else
            {
                var object = '';
                console.log('abcd');
                $.each(response, function (index, item) {
                    console.log("List" + item);
                object += '<tr>';
                object += '<td>' + item.product_ID + '</td>';
                object += '<td>' + item.product_Name + '</td>';
                object += '<td>' + item.price + '</td>';
                object += '<td>' + item.quantity + '</td>';
                    object += '<td><a href = "#" class="btn btn-primary btn-sm" onClick ="Edit(' + item.product_ID + ')">Edit</a> <a href = "#" class="btn btn-danger btn-sm" onClick="Delete(' + item.product_ID +')">Delete</a></td >';
                 object += '</tr>';
                $('#tblBody').html(object);

            });
               
        }
    },

        error: function () {
            alert('Unable to read the data');
        }

    });
}
$('#btnAdd').click(function () {
    $('#productModal').modal('show');
    $('#modalTitle').text('Add Product');
});
/*Insert Data*/
function Insert() {
    var result = Validate();
    if (result == false) {
        return false;
    }
    var formData = new Object();
    formData.product_ID = $('#Product_ID').val();
    formData.product_Name = $('#Product_Name').val();
    formData.price = $('#Price').val();
    formData.quantity = $('#Quantity').val();

    $.ajax({
        url: 'Product/PostProducts',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data...');
            }
            else {
                ClearControl();
                HideModal()
                GetProducts();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save the data...');
        }
    });
}
function HideModal() {
    $('#productModal').modal('hide');
}
function ClearControl() {
    $('#Product_ID').val('0');
    $('#Product_Name').val('');
    $('#Price').val('');
    $('#Quantity').val('');

    //$('#Product_Name').css('border-color', 'lightgrey');
    //$('#Price').css('border-color', 'lightgrey');
    //$('#Quantity').css('border-color', 'lightgrey');
}
function Validate() {
    var isValid = true;
    if ($('#Product_Name').val().trim() == "") {
        $('#Product_Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Product_Name').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
    if ($('#Quantity').val().trim() == "") {
        $('#Quantity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Quantity').css('border-color', 'lightgrey');
    }
    return isValid;
}
$('#Product_Name').change(function () {
    Validate();
});
$('#Price').change(function () {
    Validate();
})
$('#Quantity').change(function () {
    Validate();
})
function Edit(id) {
    console.log(id)
    $.ajax({
        url: 'Product/Edit?id=' + id,
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Unable to Read the data');
            }
            else if (response.length == 0) {
                alert('Data Not Available with the id' + id);
            }
            else {
                $('#productModal').modal('show');
                $('#modalTitle').text('Update Product');
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
                $('#Product_ID').val(response.product_ID);
                $('#Product_Name').val(response.product_Name);
                $('#Price').val(response.price);
                $('#Quantity').val(response.quantity);
            }
        }
    });
}
function Update() {
    var result = Validate();
    if (result == false) {
        return false;
    }
    var formData = new Object();
    formData.product_ID = $('#Product_ID').val();
    formData.product_Name = $('#Product_Name').val();
    formData.price = $('#Price').val();
    formData.quantity = $('#Quantity').val();
    $.ajax({
        url: 'Product/Update',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to Update the data...');
            }
            else {
                ClearControl();
                HideModal()
                GetProducts();
                alert(response);
                $('#Save').css('display', 'block');
                $('#Update').css('display', 'none');
            }
        },
        error: function () {
            alert('Unable to Update the data...');
        }
    });
}
function Delete(id) {
    if (confirm('Are you sure to delete this record?')) {
        $.ajax({
            url: 'Product/Delete?id=' + id,
            type: 'post',
            // dataType: 'json',
            //   contentType: 'application/json;charset=utf-8',
            success: function (response) {
                if (response == null || response == undefined) {
                    alert('Unable to Delete the data');
                }
                else if (response.length == 0) {
                    alert('Data Not Available with the id' + id);
                }
                else {
                    GetProducts();
                    alert(response)
                }
            },
            error: function () {
                alert('Unable to Delete the data');
            }
        });

    }
}