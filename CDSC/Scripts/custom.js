function sucessMessage() {
    $context = 'success';
    $message = 'Registro salvo com sucesso.';
    $position = 'top-right';

    if ($context == '') {
        $context = 'info';
    }

    if ($position == '') {
        $positionClass = 'toast-left-top';
    } else {
        $positionClass = 'toast-' + $position;
    }

    toastr.remove();
    toastr[$context]($message, '', { positionClass: $positionClass });
}

function errorMessage() {
    $context = 'error';
    $message = 'Ocorreu um erro.';
    $position = 'top-right';

    if ($context == '') {
        $context = 'info';
    }

    if ($position == '') {
        $positionClass = 'toast-left-top';
    } else {
        $positionClass = 'toast-' + $position;
    }

    toastr.remove();
    toastr[$context]($message, '', { positionClass: $positionClass });
}