// Write your JavaScript code.

// Popup
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
};

// Add or Update Object
jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action, 
            data: new FormData(form),
            contentType: false, 
            processData: false,
            success: function (res) {
                if (res.isValid) { 
                    $('#view-all').html(res.html); 
                    $('#form-modal .modal-body').html(''); 
                    $('#form-modal .modal-title').html(''); 
                    $('#form-modal').modal('hide');
                    $.notify('Submitted Successfully', { globalPosition: 'top center', className:'success' });

                }
                else { 
                    $('#form-modal .modal-body').html(res.html);

                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
    catch (e) {
        console.log(e);
    }
    return false;
}

// Delete Object 
jQueryAjaxDelete = form => {
    if (confirm('Are you sure you want to delete this record?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action, 
                data: new FormData(form),
                contentType: false, 
                processData: false, 
                success: function (res) {
                    $('#view-all').html(res.html); 
                    $.notify('Deleted Successfully', { globalPosition: 'top center', className:'success' });

                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }
    return false;
}