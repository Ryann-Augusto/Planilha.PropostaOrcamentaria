jQuery(function ($) {
        $(".valor").inputmask('currency', {
            "autoUnmask": true,
            radixPoint: ",",
            groupSeparator: ".",
            allowMinus: false,
            prefix: '',
            digits: 2,
            digitsOptional: false,
            rightAlign: true,
            unmaskAsNumber: true,
            removeMaskOnSubmit: true
        });
    });

    // retira a mascara do campo
    $(document).on("submit", function () {
        $(".valor").inputmask('unmaskedvalue');
    });