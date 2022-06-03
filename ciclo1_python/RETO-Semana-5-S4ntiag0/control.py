def estadistica(lista_tuplas_asignado, lista_tuplas_registrado):
    """Imprime un reporte que contiene:
    -  Los 3 puntos de distribución que registran mayores sobre-entregas.
    -  Los 3 puntos de distribución que registran las mayores demoras.
    -  Todos los puntos de distribución que registran ambas condiciones negativas: tanto sobre-entregas, como demora en su tiempo de despacho.

    Args:
        lista_tuplas_asignado (list)
        lista_tuplas_registrado (list)

    Returns:
        none
    """
    a = lista_tuplas_asignado
    b = lista_tuplas_registrado

    # Matriz resultado 10 filas * 3 columnas
    c = [[None for columnas in range(0, 3)] for filas in range(0, 10)]

    no_filas = len(a)
    no_columnas = len(a[0])

    for k in range(no_filas):  # Itera las filas.
        for j in range(no_columnas):  # Itera las columnas.
            c[k][j] = a[k][j] - b[k][j]  # Realiza la resta.

    # Añadimos de nuevo la enumeracion de los puntos
    enumeracion = [(1, 0, 0), (2, 0, 0), (3, 0, 0), (4, 0, 0), (5, 0, 0),
                   (6, 0, 0), (7, 0, 0), (8, 0, 0), (9, 0, 0), (10, 0, 0)]
    for k in range(no_filas):
        for j in range(no_columnas):
            c[k][j] += enumeracion[k][j]

    for i in range(len(a)):
        print(f"Punto # {i+1}")  # aqui tambien podria usar el indice
        print("Diferencia de cajas =", c[i][1])
        print("Diferencia de tiempos =", c[i][2])
        eficiencia = c[i][2] / a[i][2]
        print(f"Eficiencia = {eficiencia:.1%}")

    # Puntos con mayores demoras de tiempo
    c.sort(key=lambda x: x[2])  # Aplicamos ordenamiento
    print("Los puntos con mayores demoras de tiempo:")
    for i in range(3):
        print(f"Punto {c[i][0]}: {c[i][2]}")
    # Puntos con mayores sobre-entrega
    c.sort(key=lambda x: x[1])
    print("Los puntos con mayores sobre-entregas:")
    for i in range(3):
        print(f"Punto {c[i][0]}: {c[i][1]}")
    # Puntos con los dos criterios negativos
    print("Puntos con los dos criterios negativos:")
    for i in range(len(c)):
        if c[i][2] < 0 and c[i][1] < 0:
            print(f"Punto {c[i][0]}")
