function CheckForm() {
    var forms = document.querySelectorAll('.needs-validation')

    var form = Array.prototype.slice.call(forms)[0]

    if (form.checkValidity()) {
        form.classList.add('was-validated')
        return true
    }
    form.classList.add('was-validated')    
    return false
}