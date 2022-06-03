def validar_nombre(nombre):
    """ Valida si el nombre es string o no

    Args:
      nombre(str)

    Return:
      bool

    Examples
    --------
    >>> validar_nombre('Anita')
    True

    >>> validar_nombre('Pedro40')
    False
    """
    val_nombre = True
    if not isinstance(nombre, str):
        val_nombre = False
    if nombre.isalpha() == False:
        val_nombre = False
    return val_nombre


def validar_ident(identificacion):
    """ Valida si la identificacion cumple con:
    Longitud(Valores entre 10’000.000 y 100’000.000)

    Args:
      identificacion(str)

    Return:
      bool

    Examples
    --------
    >>> validar_ident('01234567')
    False

    >>> validar_ident('1234567')
    False

    >>> validar_ident('1234567910')
    True
    """
    val_ident = False
    if 8 <= len(identificacion) <= 10:
        primer_numero = int(identificacion[0])
        if primer_numero >= 1:
            val_ident = True
    else:
        val_ident = False
    return val_ident


def validar_correo(correo):
    """ Valida si el correo contiene el caracter '@'
    y que no se repita mas de una vez
    Args:
      correo(str)

    Return:
      bool

    Examples
    --------
    >>> validar_correo('@')
    True

    >>> validar_ident('@@')
    False

    >>> validar_ident('santiagoatgmaildotcom')
    False
    """
    val_correo = False
    if correo.rfind("@") < 0:
        val_correo = False
    elif correo.count("@") >= 2:
        val_correo = False
    else:
        val_correo = True
    return val_correo


def validar_sobrenombre(sobrenombre):
    """ Valida que el sobrenombre no inicie con
    numeros

    Args:
      sobrenombre(str)

    Return:
      bool

    Examples
    --------
    >>> validar_sobrenombre('sanurb')
    True

    >>> validar_sobrenombre('6santi')
    False
    """
    val_sobrenombre = False
    if sobrenombre[0].isdigit():
        val_sobrenombre = False
    elif sobrenombre.count("a") > 3:
        val_sobrenombre = False
    else:
        val_sobrenombre = True
    return val_sobrenombre


def validar_clave(clave):
    """ Valida que la clave contenga AL MENOS uno de
    los simbolos obligatorios

    Args:
      clave(str)

    Return:
      bool

    Examples
    --------
    >>> validar_clave('clave123_')
    True

    >>> validar_clave('clave123')
    False
    """
    val_clave = False
    simbolos_obligatorios = ["_", "?", "&"]
    # Usamos una list comprehension para comprobar
    # entiendase ele como elemento
    comprobacion = [ele for ele in simbolos_obligatorios if (ele in clave)]
    # comprobamos si la cadena clave contiene algun simbolos obligatorio
    if bool(comprobacion) == False:
        val_clave = False
    else:
        val_clave = True
    return val_clave


def asignar_zona(tiempo, tratamiento, conocimiento):
    """ Asigna una zona segun el tiempo, tratamiento y conocimiento

    Args:
      tiempo(int)
      tratamiento(str)
      conocimiento(str)
    Return:
      str

    Examples
    --------
    >>> asignar_zona(72, no, NO)
    "Sur Occidente"

    >>> asignar_zona(60, No, si)
    "Norte"

    >>> asignar_zona(80, si, no)
    "Central"

    """
    zona = ""
    if 12 > tiempo >= 60:
        if tratamiento == "NO" and conocimiento == "SI":
            zona = "Norte"
        elif tratamiento == "SI" and conocimiento == "NO":
            zona = "Sur"
    elif tiempo > 60:
        if tratamiento == "NO" and conocimiento == "SI":
            zona = "Oriente"
        elif tratamiento == "SI" and conocimiento == "SI":
            zona = "Occidente"
        elif tratamiento == "NO" and conocimiento == "NO":
            zona = "Sur Occidente"
    else:
        zona = "Central"
    return zona


def validar_informacion(
        val_nombre,
        val_ident,
        val_correo,
        val_sobrenombre,
        val_clave):
    """ Evalua si el registro es Exitoso o No Exitoso

    Args:
      val_nombre(bool)
      val_ident(bool)
      val_correo(bool)
      val_sobrenombre(bool)
      val_clave(bool)
    Return:
      str

    Examples
    --------
    >>> validar_informacion(True, True, True, True, True)
    "Registro Exitoso! Bienvenido a la Corporación Umbrella."

    >>> validar_informacion(True, False, True, True, True)
    "Registro No Exitoso, ident incorrecto."
    """
    result = val_nombre and val_ident and val_correo and val_sobrenombre and val_clave
    mensaje = ""
    parametro = ""  # Indica la primer ocurrencia de error

    if not val_clave:
        parametro = "clave incorrecto"

    elif val_sobrenombre == False:
        parametro = "sobrenombre incorrecto"

    elif val_correo == False:
        parametro = "correo incorrecto"

    elif val_ident == False:
        parametro = "ident incorrecto"

    elif val_nombre == False:
        parametro = "nombre incorrecto"
    # Validacion de criterios
    if not result:
        mensaje = f"Registro No Exitoso, {parametro}."
    else:
        mensaje = "Registro Exitoso! Bienvenido a la Corporación Umbrella."
    return mensaje
