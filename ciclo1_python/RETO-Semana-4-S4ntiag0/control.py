total_cajas = 100
registrado = []

def control_camion(punto_distribucion, tiempo_entrega, cantidad_cajas):
    """ esta funcion realiza el conteo de las cajas
    y lleva el control del total de cajas
    """
    # guardamos total de cajas
    global total_cajas
    global registrado
    total_cajas = total_cajas - cantidad_cajas
    # Guardamos los argumentos en un container y despues en otra lista de lo registrado
    container = [punto_distribucion, cantidad_cajas, tiempo_entrega]
    registrado.append(container)
  
    imprimir_alertas(tiempo_entrega, cantidad_cajas)
    print(f"\n🏤 Punto de distribución #{punto_distribucion}")
    for i in range(0, cantidad_cajas):
        print("\n📦 Caja #", i + 1)
    # Salidas
    print("\nEl total de cajas en inventario en el camión =", total_cajas)
    print("\nTiempo de despacho =", tiempo_entrega)
    

def imprimir_alertas(tiempo_entrega, cantidad_cajas):
    """ esta funcion imprime si el camion excede el tiempo de entrega, o si la cantidad de cajas es inferior a la deseada
    """
    if tiempo_entrega > 15:
        print("\n⚠️: Se excede el límite de tiempo \n")
    if cantidad_cajas < 10:
        print("⚠️: La cantidad de cajas de vacunas a despachar en cada punto de distribución es inferior a la mínima ideal/sugerida (10) \n")
    if total_cajas == 0:
        print("⚠️: Se ha agotado el inventario en el camión \n")


def ver_inventario():
    """ esta imprime en pantalla el total de cajas
    actuales
    """
    print(f"el inventario actual es {total_cajas}")

def generar_reporte():
    """ Imprime en pantalla el total de la informacion
    de cada punto de distribucion
    """
    # Ordenamos por Punto de distribucion
    registrado.sort(key=lambda x: x[0]) 
    for i in range(len(registrado)):
        print(f"Punto #{registrado[i][0]}\n")
        print(f"Cantidad de cajas despachadas = {registrado[i][1]}\n")
        print(f"Tiempo de despacho = {registrado[i][2]}\n")
    # Total de cajas
    print(f"Total de cajas despachadas = {100-total_cajas}")
    
      