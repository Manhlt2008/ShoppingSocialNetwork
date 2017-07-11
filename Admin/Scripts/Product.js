function goBack() {
    window.history.go(-1);
}

function InsertProduct() {
    var product = new Object();
    product.Name = $("#txtName").val();
    product.Description = $("#txtDescription").val();
    product.Price = $("#txtPrice").val();
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(product) + '}',
        url: '/Product/InsertProduct',
        contentType: "application/json",
        success: function (data) {
            window.location = '/';
        },
        error: function () {
            console.log("Thêm mới sản phẩm lỗi!!!");
        }
    });
}
function SaveProduct() {
    var product = new Object();
    product.ProductId = $("#productId").val();
    product.Name = $("#txtName").val();
    product.Description = $("#txtDescription").val();
    product.Price = $("#txtPrice").val();
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(product) + '}',
        url: '/Product/UpdateProduct',
        contentType: "application/json",
        success: function (data) {
            if(data==1) alert("Sửa sản phẩm thành công");
            window.location = '/';
        },
        error: function () {
            console.log("Sửa sản phẩm lỗi!!!");
        }
    });
}

$(document).on("click", ".open-DeleteDialog", function () {
    var productId = $(this).data('id');
    $(".modal-body #prId").val(productId);
    $('#modal-delete').modal('show');
});
function DeleteProduct() {
        $.ajax({
        type: 'POST',
        data: '{ productId:' + $("#prId").val() + '}',
        url: '/Product/DeleteProduct',
        contentType: "application/json",
        success: function (data) {
            window.location = '/';
        },
        error: function () {
            console.log("Xóa sản phẩm lỗi!!!");
        }
    });
}