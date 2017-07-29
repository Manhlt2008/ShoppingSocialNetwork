function LogIn()
{
    var userName = $("#txtUser").val().trim();
    var pass = $("#txtPass").val().trim();
    if (userName == "") {
        $("#error").text("Vui lòng nhập username.");
        $("#txtUser").focus();
        return;
    }
    if (pass == "") {
        $("#error").text("Vui lòng nhập password.");
        $("#txtPass").focus();
        return;
    }
    $.ajax({
        type: 'POST',
        data: '{ userName:"' + userName + '",pass:"' + pass + '"}',
        url: '/Account/LoginPost',
        contentType: "application/json",
        success: function (data) {
            switch (data) {
                case 1:
                    window.location = '/UserGroup/Index';
                    break;
                case 4:
                    $("#error").text("Username hoặc mật khẩu không đúng.");
                    break;
                default:
                    $("#error").text("Có lỗi trong quá trình xử lý, Xin vui lòng thử lại!");
                    break;
            } 
        },
        error: function () {
            console.log("Sửa nhóm người dùng lỗi!!!");
        }
    });
}