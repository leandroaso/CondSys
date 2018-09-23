
$('.datepicker').mask('99/99/9999', { placeholder: "mm/dd/yyyy" });

function Edit(data) {
    limparFormulario()
    var modal = $("#myModal");
    modal.find("#Assembleia_Id").val(data.Id);
    modal.find("#Assembleia_Data").val(data.Data);
    modal.find("#Assembleia_Titulo").val(data.Titulo);
    modal.find("#Assembleia_Descricao").html(data.Descricao);

    modal.modal('show');
}

function Cacelar(id, url) {
    const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false,
    });

    swalWithBootstrapButtons({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            console.log(id);
            $.ajax({
                type: "POST",
                url: url,
                data: "id=" + id,
                success: function (response) {
                    if (response == "success") {
                        location.reload();
                    } else {
                        swal(
                            'Ops!',
                            'houve um problema ao tentar cencelar a assembleia, tente novamente mais tarde!',
                            'warning'
                        ).then(() => {
                            location.reload();
                        });
                    }
                },
                error: function (response) {
                    swal(
                        'Erro!',
                        'houve um problema ao tentar cencelar a assembleia, tente novamente mais tarde!',
                        'error'
                    ).then(() => {
                        location.reload();
                    });
                }

            });
        }
    });
}

function formSubmit() {

    var form = $("#fomulario");

    $.ajax({
        type: "POST",
        url: form.attr('action'),
        data: form.serialize(),
        success: function (response) {
            if (response == "OK") {
                location.reload();
            } else {
                swal(
                    'Ops!',
                    response.Message,
                    'warning'
                ).then(() => {
                    location.reload();
                });
            }
        },
        error: function (response) {
            swal(
                'Erro!',
                'houve um problema ao tentar realizar o cadastro, verifique se os dados estão corretos',
                'error'
            ).then(() => {
                location.reload();
            });
        }

    });
}

function limparFormulario() {
    $('#fomulario input').val("");
    $('#fomulario textarea').html("");
}