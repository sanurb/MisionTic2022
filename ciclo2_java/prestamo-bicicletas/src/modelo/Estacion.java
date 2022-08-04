package modelo;

import java.util.HashMap;

public class Estacion {
    // Atributo
    private int id; 
    private String ubicacion; 
    // Relacion 1 Estacion tiene 1..* Bicicletas
    private Bicicleta[] bicicletas;
    private int cantidadPrestamos;
    
    // Constructor

    public Estacion(String ubicacion, Bicicleta[] bicicletas, int cantidadPrestamos) {
        this.ubicacion = ubicacion;
        this.bicicletas = bicicletas;
        this.cantidadPrestamos = cantidadPrestamos;
    }    
    
    public Estacion() {
    } 

    public Estacion(Bicicleta[] bicicletas) {
        this.bicicletas = bicicletas;
    }

    public Estacion(int id, String ubicacion, Bicicleta[] bicicletas, int cantidadPrestamos) {
        this.id = id;
        this.ubicacion = ubicacion;
        this.bicicletas = bicicletas;
        this.cantidadPrestamos = cantidadPrestamos;
    }

    public Estacion(int id, String ubicacion, int cantidadPrestamos) {
        this.id = id;
        this.ubicacion = ubicacion;
        this.cantidadPrestamos = cantidadPrestamos;
    }
        
    //get
    
    public int getId() {
        return id;
    }

    public String getUbicacion() {
        return ubicacion;
    }

    public Bicicleta[] getBicicletas() {
        return bicicletas;
    }

    public int getCantidadPrestamos() {
        return cantidadPrestamos;
    }
    
   
}
