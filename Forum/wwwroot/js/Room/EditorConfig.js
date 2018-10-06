
$(document).ready(() => {
    CKEDITOR.editorConfig = function (config) {
        config.toolbarGroups = [
            { name: 'document', groups: ['mode', 'document', 'doctools'] },
            { name: 'clipboard', groups: ['clipboard', 'undo'] },
            { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
            { name: 'forms', groups: ['forms'] },
            '/',
            { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
            { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
            { name: 'links', groups: ['links'] },
            { name: 'insert', groups: ['insert'] },
            '/',
            { name: 'styles', groups: ['styles'] },
            { name: 'colors', groups: ['colors'] },
            { name: 'tools', groups: ['tools'] },
            { name: 'others', groups: ['others'] },
            { name: 'about', groups: ['about'] }
        ];

        config.removeButtons = 'Save,NewPage,Preview,Print,Templates,PasteFromWord,PasteText,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,RemoveFormat,CopyFormatting,CreateDiv,Image,Flash,HorizontalRule,PageBreak,Iframe,ShowBlocks';
    };
    CKEDITOR.replace('editor');

});
var SendPost = () => {
    $("#post-status").text("Loading...");
    $.ajax({
        url: "/Post/CreatePost",
        type: "POST",
        data: {
            RoomId: parseInt(window.location.pathname.split('/').pop()),
            Message: CKEDITOR.instances['editor'].getData()
        },
        success: onSucces,
        error: onFailure,
        complete: () => { $("#post-status").text(""); }
    });
};

var onSucces = () => {
    console.log("adas");
    location.reload();
}
var onFailure = () => {
    alert("Message doesn't meet requerements");
}