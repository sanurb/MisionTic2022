import csv
# Librerias para graficar
import matplotlib.pyplot as plt
import matplotlib.style as mplstyle
import pandas as pd


def leer_archivos(punto_distribucion):
    """
    Esta funcion lee y almacena los datos para cada uno de los archivos,
    recorriendo cada fila y guardandolos en una nueva matriz.
    Realiza el llamado a las funciones validar_punto_distribucion y control

    Args:
        punto_distribucion (int)
    Return:
        tabla_asignados(list of list)
        tabla_registrados(list of list)
    """
    asignados = open("ValoresAsignados.csv", "r")
    registrados = open("ValoresRegistrados.csv", "r")

    tabla_asignados = []
    for fila in csv.reader(asignados):
        tabla_asignados.append(fila)
    asignados.close()

    tabla_registrados = []
    for fila in csv.reader(registrados):
        tabla_registrados.append(fila)
    registrados.close()

    validar_punto_distribucion(punto_distribucion, tabla_asignados)
    control(punto_distribucion, tabla_asignados, tabla_registrados)

    return tabla_asignados, tabla_registrados


def validar_punto_distribucion(
        punto_distribucion,
        tabla_asignados):
    """ Verifica si el punto de distribucion está dentro del rango de
    valores registrados.

    Args:
        punto_distribucion (int)
        tabla_asignados(list of list)
    Return:
        none
    """
    if 1 <= punto_distribucion <= len(tabla_asignados):
        pass
    else:
        print("Punto de distribucion no encontrado")
        exit()


def contar_entregas_a_tiempo(
        tabla_asignados,
        tabla_registrados):
    """Esta funcion realiza el conteo de cajas entragadas a tiempo.

    Args:
        tabla_asignados(list of list)
        tabla_registrados(list of list)
    Return:
        entregas_atiempo(int)
    """
    num_entregas_atiempo = 0
    for i in range(len(tabla_asignados)):
        if tabla_asignados[i][2] < tabla_registrados[i][2]:
            num_entregas_atiempo += 1

    entregas_atiempo = 100 * num_entregas_atiempo / len(tabla_asignados) - 1
    return entregas_atiempo


def control(
        punto_distribucion,
        tabla_asignados,
        tabla_registrados):
    """Realiza los calculos para el punto de distribucion digitado,
    y también registra los indicadores para todos los puntos de distribucion.

    Args:
        punto_distribucion (int)
        tabla_asignados(list of list)
        tabla_registrados(list of list)
    Return:
        tabla_estadisticas(list of list)
    """
    # Variables para los calculos individuales
    iterador = punto_distribucion
    t_total_asignado = int(tabla_asignados[iterador][2])
    t_total_registrado = int(tabla_registrados[iterador][2])
    total_cajas_despachadas = int(tabla_registrados[iterador][1])
    total_cajas_asignadas = int(tabla_asignados[iterador][1])
    contar_entregas_a_tiempo(tabla_asignados, tabla_registrados)

    # Formulas indicadores
    eficiencia = 100 * (t_total_asignado -
                        t_total_registrado) / t_total_asignado
    tasa_entrega = total_cajas_despachadas / t_total_registrado
    nivel_cumplimiento = 100 * \
        (total_cajas_despachadas / total_cajas_asignadas)
    entregas_tiempo = contar_entregas_a_tiempo(
        tabla_asignados, tabla_registrados)

    # todo: Busqueda binaria para mejorar complejidad
    if tabla_asignados[iterador][0] in str(iterador):
        print(f"Eficiencia en tiempos de despacho = {eficiencia:.1f} %")
        print(f"Tasa de entrega = {tasa_entrega:.1f} cajas/min")
        print(
            f"Nivel de cumplimiento de los despachos = {nivel_cumplimiento:.1f} %")
        print(f"Entregas a tiempo = {entregas_tiempo:.1f} %")

    # III.Registro Estadisticas
    iterador = 1
    matriz_indicadores = [[0] * 4 for _ in range(len(tabla_asignados))]
    # Asignamos encabezados a la matriz_indicadores
    matriz_indicadores[0][0] = "PuntoDistribucion"
    matriz_indicadores[0][1] = "EficienciaTiemposDespacho_%"
    matriz_indicadores[0][2] = "TasaEntrega_cajas/min"
    matriz_indicadores[0][3] = "NivelCumplimientoDespachos_%"

    while iterador < len(matriz_indicadores):
        t_total_asignado = int(tabla_asignados[iterador][2])
        t_total_registrado = int(tabla_registrados[iterador][2])
        total_cajas_despachadas = int(tabla_registrados[iterador][1])
        total_cajas_asignadas = int(tabla_asignados[iterador][1])
        # Calcular eficiencia
        eficiencia = 100 * (t_total_asignado -
                            t_total_registrado) / t_total_asignado
        # Calcular tasa de entrega
        tasa_entrega = total_cajas_despachadas / t_total_registrado
        # Nivel de cumplimiento de los despachos
        nivel_cumplimiento = 100 * \
            (total_cajas_despachadas / total_cajas_asignadas)

        matriz_indicadores[iterador][0] = f"{iterador}"
        matriz_indicadores[iterador][1] = f"{eficiencia:.1f}"
        matriz_indicadores[iterador][2] = f"{tasa_entrega:.1f}"
        matriz_indicadores[iterador][3] = f"{nivel_cumplimiento:.1f}"
        iterador += 1

    with open('registro_estadisticas.csv', 'w', newline='') as f:
        writer = csv.writer(f)
        writer.writerows(matriz_indicadores)

    estadisticas = open("registro_estadisticas.csv", "r")
    tabla_estadisticas = []
    for fila in csv.reader(estadisticas):
        tabla_estadisticas.append(fila)
    estadisticas.close()

    # IV. Graficas
    graficar(tabla_asignados, tabla_registrados, tabla_estadisticas)
    return tabla_estadisticas


def graficar(tabla_asignados, tabla_registrados, tabla_estadisticas):
    """Esta funcion es la encargada de realizar la graficas con matplotlib

    la forma alternativa de guardar las columnas de una matriz sin usar list-comprehension
    es usando un loop for pero es menos elegante
    for i in range(len(tabla_asignados)):
        cajas.append(tabla_asignados[i][1])
    """
    f1 = tabla_asignados
    f2 = tabla_registrados
    mplstyle.use('ggplot')

    # i. Carga_cajas(EjeY) vs PuntoDistribucion(EjeX)
    # ordenamos por Cargas de cajas ascendentemente
    f1.sort(key=lambda x: x[1])
    f2.sort(key=lambda x: x[1])

    cargas_cajas_f1 = [caja[1] for caja in f1[:-1]]  # generamos vector
    cargas_cajas_f2 = [caja[1] for caja in f2[:-1]]
    puntos_distribucion_f1 = [pto_distribucion[0]
                              for pto_distribucion in f1[:-1]]
    puntos_distribucion_f2 = [pto_distribucion[0]
                              for pto_distribucion in f2[:-1]]
    # i. Graficamos con los vectores
    plt.plot(puntos_distribucion_f1, cargas_cajas_f1)
    plt.xlabel('Punto Distribucion')
    plt.ylabel('Carga cajas')
    plt.xticks(rotation=70)
    plt.title('columna de Carga cajas(EjeY) vs Punto Distribucion(EjeX)')
    plt.savefig('grafica1.png', dpi=300, bbox_inches='tight')
    plt.close()

    plt.plot(puntos_distribucion_f2, cargas_cajas_f2)
    plt.xlabel('Punto Distribucion')
    plt.ylabel('Carga cajas')
    plt.xticks(rotation=70)
    plt.title('columna de Carga cajas(EjeY) vs Punto Distribucion(EjeX)')
    plt.savefig('grafica2.png', dpi=300, bbox_inches='tight')
    plt.close()
    # II. F1: Tiempo_minutos(EjeY) vs PuntoDistribucion(EjeX)
    f1.sort(key=lambda x: x[2])
    tiempo_f1 = [despacho[2] for despacho in f1[:-1]]
    points_by_time_f1 = [pto_distribucion[0]
                         for pto_distribucion in f1[:-1]]
    plt.stem(points_by_time_f1, tiempo_f1)
    plt.xlabel('Punto Distribucion')
    plt.ylabel('Tiempo en minutos')
    plt.xticks(rotation=70)
    plt.title('Tiempo (EjeY) vs Punto Distribucion(EjeX')
    plt.savefig('grafica3.png', dpi=300, bbox_inches='tight')
    plt.close()

    # II. Para f2 graficamos desde dataframes
    df2 = pd.DataFrame(tabla_registrados[:-1],  # creamos data frame
                       columns=['PuntoDistribucion',
                                'CargaEntregada_cajas',
                                'TiempoDespacho_minutos'])
    tiempo_f2 = df2.sort_values(
        'TiempoDespacho_minutos')  # Ordenamos por tiempo
    plt.plot(tiempo_f2['PuntoDistribucion'],
             tiempo_f2['TiempoDespacho_minutos'])

    plt.xlabel('Punto Distribucion')
    plt.ylabel('Tiempo en minutos')
    plt.xticks(rotation=70)
    plt.title('Tiempo (EjeY) vs Punto Distribucion(EjeX')
    plt.savefig('grafica4.png', dpi=300, bbox_inches='tight')
    plt.close()

    # III. F1 Y F2: Carga_cajas(EjeY) vs PuntoDistribucion(EjeX)
    # para esta gráfica lo que quiero hacer es dividirla en dos, ya que tienen
    # distintos ejesY
    # retorna una tupla con una figura y objetos de ejes
    fig, ax = plt.subplots(nrows=1, ncols=2, figsize=(20, 5))
    ax[0].plot(puntos_distribucion_f1, cargas_cajas_f1, label='carga')
    ax[0].set_xlabel('Punto Distribucion')
    ax[0].set_ylabel('Carga')
    ax[0].set_title('Carga vs Punto Distribucion')
    # editamos el segundo eje
    ax[1].plot(points_by_time_f1,
               tiempo_f1, 'g', label='tiempo')
    ax[1].set_xlabel('Punto Distribucion')
    ax[1].set_ylabel('Tiempo')
    ax[1].set_title('Tiempo vs Punto Distribucion')
    plt.savefig('grafica5.png', dpi=300, bbox_inches='tight')
    plt.close()

    # f1 y f2: Tiempo vs Punto Distribucion
    # Gráfica comparativa de tiempos
    df1 = pd.DataFrame(tabla_asignados[:-1],
                       columns=['PuntoDistribucion',
                                'CargaEntregada_cajas',
                                'TiempoDespacho_minutos'])
    df3 = pd.merge(df1, df2, on='PuntoDistribucion', suffixes=('_1', '_2'))
    # Ordenamos por punto de distribucion
    df3 = df3.astype('int64')  # convertimos de obj a int
    df3 = df3.sort_values(by='PuntoDistribucion')

    agrup = df3.groupby('PuntoDistribucion').agg({
        'TiempoDespacho_minutos_1': 'mean',
        'TiempoDespacho_minutos_2': 'mean'
    })

    fig, ax = plt.subplots(figsize=(8, 7))

    ax.plot(agrup['TiempoDespacho_minutos_1'], label='Asignados')
    ax.plot(agrup['TiempoDespacho_minutos_2'], label='Registrados')

    ax.set_xlabel('Punto Distribucion')
    ax.set_ylabel('Tiempo en minutos')
    ax.legend()
    plt.savefig('grafica6.png', dpi=300, bbox_inches='tight')
    plt.close()
