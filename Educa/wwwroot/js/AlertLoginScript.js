let inputValue = document.getElementById("Active").value;
let timerInterval
if (inputValue === "Enable") {
    document.getElementById("Active").value = "Bienvenido!";
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 4000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    });

    Toast.fire({
        icon: 'error',
        title: 'Usuario y/o contraseña incorrectos.'
    });
    
    
}
