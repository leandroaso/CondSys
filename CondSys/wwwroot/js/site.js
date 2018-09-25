
//$('.datepicker').mask('99/99/9999', { placeholder: "mm/dd/yyyy" });

$(document).ready(function () {
    $(".datepicker").mask("99/99/9999");
});

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
        title: 'Você tem certeza?',
        text: "Está ação não poderá ser desfeita!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sim!',
        cancelButtonText: 'Não',
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

    if (form.find("#Assembleia_Data").val() == null ||
        form.find("#Assembleia_Data").val() == "" ||
        form.find("#Assembleia_Data").val() == undefined) {
        form.find(".validar-data").removeClass("hidden");
        form.find(".validar-data").html("Campo Data é obrigatório");
        return false;
    } else {
        form.find(".validar-data").addClass("hidden");
    }
    if (form.find("#Assembleia_Titulo").val() == null ||
        form.find("#Assembleia_Titulo").val() == "" ||
        form.find("#Assembleia_Titulo").val() == undefined) {
        form.find(".validar-titulo").removeClass("hidden");
        form.find(".validar-titulo").html("Campo Titulo é obrigatório");
        return false;
    } else {
        form.find(".validar-titulo").addClass("hidden");
    }
    if (form.find("#Assembleia_Descricao").val() == null ||
        form.find("#Assembleia_Descricao").val() == "" ||
        form.find("#Assembleia_Descricao").val() == undefined) {
        form.find(".validar-descricao").removeClass("hidden");
        form.find(".validar-descricao").html("Campo Descrição é obrigatório");
        return false;
    } else {
        form.find(".validar-descricao").addClass("hidden");
    }

    $.ajax({
        type: "POST",
        url: form.attr('action'),
        data: form.serialize(),
        success: function (response) {
            if (response.status == "OK") {
                location.reload();
            } else {
                console.log(response);
                swal(
                    'Ops!',
                    'A assembleia só pode ser marcada em um prazo de até 15 dias',
                    'warning'
                ).then(() => {
                    //location.reload();
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