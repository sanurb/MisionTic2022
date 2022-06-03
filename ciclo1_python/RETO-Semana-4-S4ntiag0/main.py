import control as ctrl


def mostrarMenu():
    print("***********************")
    print("  MENU")
    print("***********************")
    print("""¿qué quieres hacer? \n
  [1] Registrar Entrega en Punto de Distribuccion
  [2] Ver Inventario
  [3] Generar reporte de cada despacho
      """)
    opt = input("Digita una opcion entre 1 y 3: ")
    print("*********************** \n")
    return opt


def main():
    while flag:
        opt = mostrarMenu()
        if opt == '1':
            try:
              punto_distribucion = int(input(
                "Digite el punto de distribucion(1 al 10): "))
              tiempo_entrega = int(input("Ingrese el tiempo de entrega: "))
              cantidad_cajas = int(input("Ingrese la cantidad de cajas: "))
            except ValueError:
                print("Error: Debe digitar un numero")
                break  
            

            ctrl.control_camion(
                punto_distribucion,
                tiempo_entrega,
                cantidad_cajas)
        elif opt == '2':
            ctrl.ver_inventario()
        elif opt == '3':
            ctrl.generar_reporte()


flag = True
while flag:
    main()
    continuar = input("Desea continua(s/N): ").upper()
    if continuar == "N":
        flag = False

# fin
