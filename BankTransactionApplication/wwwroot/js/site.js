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
            url: form.action, // url for post action method from this form
            data: new FormData(form), // passs the data from form controls
            contentType: false, // for input controls
            processData: false, // for input controls
            success: function (res) {
                if (res.isValid) { // check if validation is successful or not
                    $('#view-all').html(res.html); // replace code in the ViewAll div
                    $('#form-modal .modal-body').html(''); //clear modal body
                    $('#form-modal .modal-title').html(''); // clear modal title
                    $('#form-modal').modal('hide');
                    // Add loading notification
                    $.notify('Submitted Successfully', { globalPosition: 'top center', className:'success' });

                }
                else { // update the modal body if error messages with addoredit form
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
    // to prevent default form submit
    return false;
}

// Delete Object 
jQueryAjaxDelete = form => {
    if (confirm('Are you sure you want to delete this record?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action, // url for post action method from this form
                // add data, contentType and processData properties for the validateforgerytokens
                data: new FormData(form), // passs the data from form controls
                contentType: false, // for input controls
                processData: false, // for input controls
                success: function (res) {
                    $('#view-all').html(res.html); // replace code in the ViewAll div
                    // Add loading notification
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
    // to prevent default form submit
    return false;
}


