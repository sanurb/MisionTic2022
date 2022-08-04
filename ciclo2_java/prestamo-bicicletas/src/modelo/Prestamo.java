package modelo;

public class Prestamo {
    // Atributos
    private int id;
    private int idUsuario;
    private String idBicicleta;
    private int idEstacion;
    private String modeloBicleta;
    
    
    // Constructor
    public Prestamo(int idUsuario, String idBicicleta, String modeloBicleta) {
        this.idUsuario = idUsuario;
        this.idBicicleta = idBicicleta;
        this.modeloBicleta = modeloBicleta;
    }

    public Prestamo(int idUsuario, String idBicicleta, String modeloBicleta, int idEstacion) {
        this.idUsuario = idUsuario;
        this.idBicicleta = idBicicleta;
        this.modeloBicleta = modeloBicleta;
        this.idEstacion = idEstacion;
    }

    public Prestamo(int id, int idUsuario, String idBicicleta, int idEstacion) {
        this.id = id;
        this.idUsuario = idUsuario;
        this.idBicicleta = idBicicleta;
        this.idEstacion = idEstacion;
    }
    
    // get
    
    public int getId() {
        return id;
    }

    public int getIdUsuario() {
        return idUsuario;
    }

    public String getIdBicicleta() {
        return idBicicleta;
    }

    public String getModeloBicleta() {
        return modeloBicleta;
    }
    
    public int getIdEstacion() {
        return idEstacion;
    }
    
    // Medotos logicas del negocio
    
    public int consultarDescuento(Prestamo[] historialPrestamo, Prestamo nuevoPrestamo){
        int contadora = 0;
        int descuento = 0;
        
        //1) Recorrer la estructura de datos (historialPrestamo)
        for (Prestamo prestamo : historialPrestamo) {
            if(prestamo.getIdUsuario() == nuevoPrestamo.getIdUsuario()){
                contadora += 1;
            }
        }
        
        //2) Hallar el valor a descontar partiendo del numero de prestamo del usuario
        if(contadora < 3){
            descuento = 0; 
        }else{
            if(contadora >=3 && contadora <= 5){
                descuento = 4; 
            }else{
                
                if(nuevoPrestamo.getModeloBicleta().equals("Standard")){
                    descuento = 8; 
                }else{
                    descuento = 9; 
                }
            }
        }

        return descuento;
    }

    

}
