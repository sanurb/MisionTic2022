import control


lista_tuplas_asignado = [
    (1, 98, 11),
    (2, 86, 14),
    (3, 99, 11),
    (4, 89, 12),
    (5, 89, 12),
    (6, 96, 10),
    (7, 93, 13),
    (8, 87, 15),
    (9, 89, 10),
    (10, 92, 10),
]

lista_tuplas_registrado = [
    (1, 100, 10),
    (2, 86, 10),
    (3, 97, 15),
    (4, 93, 15),
    (5, 94, 12),
    (6, 93, 13),
    (7, 95, 12),
    (8, 85, 11),
    (9, 90, 11),
    (10, 90, 12),
]

control.estadistica(lista_tuplas_asignado, lista_tuplas_registrado)
