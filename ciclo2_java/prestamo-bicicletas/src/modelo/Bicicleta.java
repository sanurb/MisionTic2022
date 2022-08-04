package modelo;

public class Bicicleta {
    // Atributos
    private String id;
    private String modelo;
    private String matricula;
    
    // Constructor
    public Bicicleta(String id, String modelo) {
        this.id = id;
        this.modelo = modelo;
    }

    public Bicicleta(String id, String modelo, String matricula) {
        this.id = id;
        this.modelo = modelo;
        this.matricula = matricula;
    }
        
    // get

    public String getId() {
        return id;
    }

    public String getModelo() {
        return modelo;
    }

    public String getMatricula() {
        return matricula;
    }
    
}
