function goBack() {
    window.history.go(-1);
}

function InsertProduct() {
    var product = new Object();
    product.ProTypeID = $("#ddlProTypeID").val();
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
    product.ProTypeID = $("#ddlProTypeID").val();
    product.ProductId = $("#productId").val();
    product.Name = $("#txtName").val();
    product.Description = $("#txtDescription").val();
    product.Price = $("#txtPrice").val();
    console.log(product);
    return;
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
//usergroup
function InsertUserGroup() {
    var ug = new Object();
    ug.GroupID = $("#txtGroupID").val();
    ug.GroupName = $("#txtGroupName").val();
    ug.Note = $("#txtNote").val();
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(ug) + '}',
        url: '/UserGroup/InsertUserGroup',
        contentType: "application/json",
        success: function (data) {
            window.location = '/UserGroup/Index';
        },
        error: function () {
            console.log("Thêm mới nhóm người dùng lỗi!!!");
        }
    });
}
function SaveUserGroup() {
    var ug = new Object();
    ug.GroupID = $("#groupId").val();
    ug.GroupName = $("#txtGroupName").val().trim();
    ug.Note = $("#txtNote").val().trim();
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(ug) + '}',
        url: '/UserGroup/UpdateUserGroup',
        contentType: "application/json",
        success: function (data) {
            if (data == 1) alert("Sửa nhóm người dùng thành công");
            window.location = '/UserGroup/Index';
        },
        error: function () {
            console.log("Sửa nhóm người dùng lỗi!!!");
        }
    });
}
$(document).on("click", ".open-delete-ug", function () {
    var ugId = $(this).data('id');
    $(".modal-body #ugId").val(ugId);
    $('#modal-delete-ug').modal('show');
});
function DeleteUserGroup() {
    $.ajax({
        type: 'POST',
        data: '{ groupId:"' + $("#ugId").val() + '"}',
        url: '/UserGroup/DeleteUserGroup',
        contentType: "application/json",
        success: function (data) {
            window.location = '/UserGroup/Index';
        },
        error: function () {
            console.log("Xóa sản phẩm lỗi!!!");
        }
    });
}

//ProductType
function InsertProductType() {
    var productT = new Object();
    productT.ProTypeId = $("#txtProTypeId").val().trim();
    productT.Name = $("#txtName").val().trim();
    productT.Note = $("#txtNote").val().trim();
    
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(productT) + '}',
        url: '/Product/InsertProductType',
        contentType: "application/json",
        success: function (data) {
            window.location = '/Product/ProductType';
        },
        error: function () {
            console.log("Thêm loại sản phẩm lỗi!!!");
        }
    });
}
function UpdateProductType() {
    var pt = new Object();
    pt.ProTypeId = $("#proTypeId").val();
    pt.Name = $("#txtName").val().trim();
    pt.Note = $("#txtNote").val().trim();
    $.ajax({
        type: 'POST',
        data: '{ model:' + JSON.stringify(pt) + '}',
        url: '/Product/UpdateProductType',
        contentType: "application/json",
        success: function (data) {
            if (data == 1) alert("Sửa loại sản phẩm thành công");
            window.location = '/Product/ProductType';
        },
        error: function () {
            console.log("Sửa loại sản phẩm dùng lỗi!!!");
        }
    });
}
$(document).on("click", ".open-delete-pt", function () {
    var id = $(this).data('id');
    $(".modal-body #ptId").val(id);
    $('#modal-delete').modal('show');
});
function DeleteProductType() {
    $.ajax({
        type: 'POST',
        data: '{ proTypeId:"' + $("#ptId").val() + '"}',
        url: '/Product/DeleteProductType',
        contentType: "application/json",
        success: function (data) {
            window.location = '/Product/ProductType';
        },
        error: function () {
            console.log("Xóa nhóm sản phẩm lỗi!!!");
        }
    });
}