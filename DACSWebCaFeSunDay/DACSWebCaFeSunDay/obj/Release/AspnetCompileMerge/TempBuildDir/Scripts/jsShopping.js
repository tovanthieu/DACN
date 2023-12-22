$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        /*alert(id + " " + quantity);*/
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                } else {
                    if (rs.code) {
                        // Sản phẩm đã hết hàng
                        alert("Số lượng sản phẩm trong kho đã hết.");
                    } else {
                        // Chưa đăng nhập
                        alert("Bạn cần đăng nhập để thêm sản phẩm vào giỏ hàng.");
                    }
                }
            }
        });
    });
    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = $('#Quantity_' + id).val();
        var maxQuantity = parseInt($('#Quantity_' + id).attr('data-max-quantity'));
        var errorMessageElement = $('#quantityErrorMessage_' + id);

        if (quantity < 0 || quantity > maxQuantity) {
            if (quantity < 0) {
                alert('Số lượng không thể là số âm.');
            } else {
                alert('Số lượng không hợp lệ.');
            }
            return;
        } else {
         
            errorMessageElement.text('');
        }

        Update(id, quantity);
    });


    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có chắc muốn xóa hết sản phẩm này trong giỏ hàng?');
        
        if (conf == true) {
            DeleteAll();        
        }
    });
    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id')
        var conf = confirm('Bạn có chắc muốn xóa sản phẩm này ra khỏi giỏ hàng?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });
});


function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}
function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}
function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            } else {
                // Hiển thị thông báo lỗi khi cập nhật không thành công
                alert(rs.ErrorMessage || 'Số lượng không hợp lệ so với số lượng còn của sản phẩm.');
            }
        }
    });
}
function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}