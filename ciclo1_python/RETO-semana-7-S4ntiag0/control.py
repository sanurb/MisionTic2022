from pathlib import Path

import pandas as pd


def control(empresa_transp: str, id_camion: int) -> str:
    """Lee dos archivos almacenados en data, los convierte a dataframes para posteriormente
    calcular los indicadores y imprimirlos en pantalla"""
    data_path = Path('data')
    # Lecture of csv files
    df_assigned = pd.read_csv(
        filepath_or_buffer=data_path /
        'Valores_Asignados.csv',
        sep=',')
    df_registered = pd.read_csv(
        filepath_or_buffer=data_path /
        'Valores_Registrados.csv',
        sep=',')
    # Search by Empresa_transp and Id_camion
    search = df_assigned.loc[(df_assigned['Empresa_transp'] == empresa_transp) & (
        df_assigned['Id_camion'] == id_camion)]
    search_reg = df_registered.loc[(df_registered['Empresa_transp'] == empresa_transp) & (
        df_registered['Id_camion'] == id_camion)]
    #  Check if searched dataframe is empty
    if search.empty or search_reg.empty:
        print("El id del camion o la empresa de trasporte no existe")
        return 0
    else:
        filter_assigned = df_assigned.loc[df_assigned['Empresa_transp']
                                          == empresa_transp]
        filter_registered = df_registered.loc[df_registered['Empresa_transp']
                                              == empresa_transp]

    # Varibles para calcular los indicadores
    t_total_asignado = search['Tiempo_despacho'].mean()
    t_total_registrado = search_reg['Tiempo_despacho'].mean()
    total_cajas_asignadas = search['cajas_entrega'].mean()
    total_cajas_despachadas = search_reg['cajas_entrega'].mean()
    num_entregas_atiempo = (
        filter_assigned['Tiempo_despacho'] < filter_registered['Tiempo_despacho']).sum()
    # Realizar calculos de los indicadores
    eficiencia = 100 * (t_total_asignado -
                        t_total_registrado) / t_total_asignado
    tasa_entrega = total_cajas_despachadas / t_total_registrado
    nivel_cumplimiento = 100 * \
        (total_cajas_despachadas / total_cajas_asignadas)
    entregas_realizadas = len(filter_assigned)
    entregas_atiempo = 100 * num_entregas_atiempo / entregas_realizadas
    # Output
    print(
        f"Debug info: entregas a tiempo {num_entregas_atiempo} y entregas totales realizadas: {entregas_realizadas}")
    print(f"Eficiencia en tiempos de despacho = {eficiencia:.1f} %")
    print(f"Tasa de entrega = {tasa_entrega:.1f} cajas/min")
    print(
        f"Nivel de cumplimiento de los despachos = {nivel_cumplimiento:.1f} %")
    print(f"Entregas a tiempo = {entregas_atiempo:.1f} %")
