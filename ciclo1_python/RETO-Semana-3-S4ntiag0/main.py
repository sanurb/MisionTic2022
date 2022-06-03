import registro as reg


def solicitar_datos():
    """solicitar la información al usuario, hacer uso de las funciones alojadas en el script registro.py para
    validar la información, y finalmente mostrar al usuario el mensaje especificado al final del archivo   README.md
    """
    nombre = input().strip()
    identificacion = input()
    correo = input()
    sobrenombre = input()
    clave = input()
    tiempo = int(input())
    tratamiento = input().upper()
    conocimiento = input().upper()

    val_nombre = reg.validar_nombre(nombre)
    val_ident = reg.validar_ident(identificacion)
    val_correo = reg.validar_correo(correo)
    val_sobrenombre = reg.validar_sobrenombre(sobrenombre)
    val_clave = reg.validar_clave(clave)
    zona = reg.asignar_zona(tiempo, tratamiento, conocimiento)
    mensaje = reg.validar_informacion(
        val_nombre,
        val_ident,
        val_correo,
        val_sobrenombre,
        val_clave)

    # Si el registro es exitoso entonces... imprime
    if mensaje == "Registro Exitoso! Bienvenido a la Corporación Umbrella.":
        print(f"Nombre: {nombre}")
        print(f"Identificación: {identificacion}")
        print(mensaje)
        print(f"Tu zona asignada para la distribución de la vacuna es: {zona}")
        print("Que tenga un Feliz Día!")
    else:
        print(mensaje)  # Mensaje de error



solicitar_datos()