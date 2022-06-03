
def calcular_ibw(altura, genero):
  """Retorna el peso ideal y lo redondea 1 decimal

	Args:
			altura(float)
			genero(str)
	Returns:
			float
  """
  if genero == "M" or "m":
     ibw = round(56.2 + 1.41*(altura/2.54-60), 2)
  elif genero == "F" or "f":
     ibw = round(53.1 + 1.36*(altura/2.54-60), 2)
  print("su IBW es ", "{:.1f}".format(ibw))
  
def calcular_calorias(peso, tiempo, actividad):
  """Retorna las calorias quemadas

	Args:
			peso(float)
			tiempo(float)
			actividad(str)
	Returns:
			float
  """
  met = float(0)
  if actividad == "1":
   met = 2
  elif actividad == "2":
    met = 5
  elif actividad == "3":
    met = 14
  elif actividad == "4":
    met = 6
  elif actividad == "5":
    met = 9.8
  calorias_quemadas = tiempo * met * peso/200
  print("Las calorias quemadas son", calorias_quemadas)
  
def calcular_grasa(genero, edad, imc):
  """Retorna las el porcentaje de grasa corporal

	Args:
			genero(str)
			edad(int)
			imc(float)
	Returns:
			float
  """
  if genero == "M" or "m":
     grasa_corporal = 1.20*imc+0.23*edad-16.2
  elif genero == "F" or "f":
     grasa_corporal = 1.20*imc+0.23*edad-5.4

  print("Su porcentaje de grasa corporal es: " ,grasa_corporal)

def calcular_tmb(genero, peso, altura, edad):
  """Retorna el Indice Metabolico Basal

	Args:
			genero(str)
			peso(float)
			altura(float)
			edad(int)
	Returns:
			float
  """
  if genero == "M" or "m":
     tmb = 13.397*peso+4.799*edad-5.677*altura+88.362
  elif genero == "F" or "f":
     tmb = 9.247*peso+3.098*edad-4.330*altura+447.593
  print("Su  Indice Metabolico Basal es: ", tmb)

def menu():
  """
	Este menu recibe los inputs del usuario y invoca los otras funciones
  """
  fin = False
  while not(fin):
    opt_select = input("Digita una opcion entre 1 y 5: ")
    if opt_select == "1": # 1. IBW
      altura = float(input("Introduzca su estatura(cm): "))
      genero = input("Ingrese su genero(F) o (M): ")
      print(calcular_ibw(altura,genero))
    elif opt_select == "2": # 2. Quemando Calorias
      peso = float(input("Introduzca su peso(kg): "))
      tiempo = float(input("Tiempo de actividad fisica(min): "))
      actividad = input("""
      1 - Caminar
      2 - Tenis
      3 - Montar en bicicleta
      4 - Correr
      5 - Nadar
                        
      Escoja actividad fisica entre 1 y 5: 
      """)
      print(calcular_calorias(peso, tiempo, actividad))
    elif opt_select == "3": # 3. Porcentaje de grasa corporal
      peso = float(input("Introduzca su peso(kg): "))
      altura = float(input("Introduzca su estatura en metros: "))
      edad = float(input("Introduzca su edad: "))
      imc = peso/altura**2
      print(calcular_grasa(genero, edad, imc))
    elif opt_select == "4": # 4. Indice Metabolico Basal
      genero = input("Ingrese su genero(F) o (M): ")
      peso = float(input("Introduzca su peso(kg): "))
      altura = float(input("Introduzca su estatura en cm: "))
      edad = float(input("Introduzca su edad: "))
      print(calcular_tmb(genero, peso, altura, edad))
    elif opt_select == "5": # 5. Salir
      fin = True
    else:
      print(f"La opcion seleccionada no existe, intente de nuevo \n")

print("""**************
Calculadora
**************          
Menu             
[1] Peso Ideal(IBW)
[2] Calorias Quemadas
[3] Porcentaje de Grasa Corporal
[4] Indice Metabolico Basal
[5] Salir""")
menu()