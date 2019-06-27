

function createCommentItem(form, path)
{
    var service = new Itemservice({ url: 'sitecore/api/ssc/item' });
    var obj = {
        ItemName: 'comment -' + form.name.value,
        TemplateID: '{0849ACE1-3FA5-46C3-8631-59791B539F0C}',
        Name: form.name.value,
        Comment: form.comment.value

    };
    service.create(obj)
        .path(path)
        .execute()
        .then(function (item) {
            form.name.value = form.comment.value = '';
            window.alert('thanks.Your message will show on the site shortly');
        })
        .fail(function (err) {
            window.alert(err);
        });
    event.preventDefault();
    return false;

}