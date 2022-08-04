package controlador;

import modelo.Bicicleta;
import modelo.Estacion;
import java.util.ArrayList;
import java.sql.*;
import java.util.HashMap;
import javax.swing.JComboBox;
import modelo.BdData;

public class EstacionDAO extends BdData {
    
    // Metodos logicas del negocio
    
    public ArrayList<Bicicleta> biclicletasEstaciones(){
        ArrayList<Bicicleta> bicicletas = new ArrayList<>();
        Bicicleta bicicleta;
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT * FROM bd_bicicleta";
            
            Statement stmt = conn.createStatement();
            
            ResultSet result = stmt.executeQuery(sql);
            
            while(result.next()){
                
                int id  = result.getInt(1);
                String idBicicleta = result.getString(2);
                String modelo = result.getString(3);
                String matricula = result.getString(4);
                
                bicicleta = new Bicicleta(idBicicleta, modelo, matricula);
                
                bicicletas.add(bicicleta);
            }
            
            return bicicletas;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        return bicicletas;
    }
    
    public ArrayList<Bicicleta> biclicletasEstaciones(String ubicacion){
        ArrayList<Bicicleta> bicicletas = new ArrayList<>();
        Bicicleta bicicleta;
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT b.* \n" +
                         "FROM bd_bicicleta AS b, bd_estacionbicicleta AS eb, bd_estacion AS e \n" +
                         "WHERE b.id_bicicleta = eb.id_bicicleta\n" +
                         "AND e.ubicacion = ?	  \n" +
                         "AND e.id = eb.id_estacion";
            
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, ubicacion);
            
            ResultSet result = stmt.executeQuery();
            
            while(result.next()){
                
                int id  = result.getInt(1);
                String idBicicleta = result.getString(2);
                String modelo = result.getString(3);
                String matricula = result.getString(4);
                
                bicicleta = new Bicicleta(idBicicleta, modelo, matricula);
                
                bicicletas.add(bicicleta);
            }
            
            return bicicletas;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        return bicicletas;
    }
    
    public Estacion consultaEstacionUbicacion(String ubicacion){
        Estacion estacion = null;
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT * FROM `bd_estacion` WHERE ubicacion = ?";
            
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, ubicacion);
            
            ResultSet result = stmt.executeQuery();
            
            while(result.next()){
                
                int id = result.getInt(1);
                String ubicacionBd = result.getString(2);
                int ctdPrestamos = result.getInt(3);
                
                estacion =  new Estacion(id, ubicacion, cantidadPrestamoEstacion(ubicacion));
            }
            
            stmt.close();
            result.close();
                    
            return estacion;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
            
        }
        return estacion;
    }
    
    public void consultarEstacion(JComboBox estacion){

        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT id, ubicacion FROM bd_estacion";
            Statement stmt = conn.createStatement();
            ResultSet resul = stmt.executeQuery(sql);
            
            while(resul.next()){
                estacion.addItem(resul.getString(1) + "-"  + resul.getString(2));
            }
           
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
    }
    
    public int cantidadPrestamoEstacion(String ubicacion){
        
        int cantidadPrestamos = 0;
        
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT COUNT(p.id)\n" +
                         "FROM `bd_prestamo` AS p, bd_estacion AS e\n" +
                         "WHERE p.id_estacion = e.id AND e.ubicacion = ?";
            
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, ubicacion);
            
            ResultSet result = stmt.executeQuery();
            
            while(result.next()){
                cantidadPrestamos = result.getInt(1);
            }
            
            stmt.close();
            result.close();
            
            return cantidadPrestamos;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        
        return cantidadPrestamos;
    }
    
    public static void burbuja(Estacion[] estaciones){
        Estacion temp = new Estacion();
        for (int i = 1; i < estaciones.length; i++) {
            for (int j = 0; j < estaciones.length - 1; j++) {
                //Se comparan las cantidades de los prestamos entre los elementos del 
                //vector para realizar el oredenamiento de las posiciones del mismo
                //importante tener presente el signo para ordenar de > mayor a menor o de < menor
                // a mayor 
                if(estaciones[j].getCantidadPrestamos()<estaciones[j+1].getCantidadPrestamos()){
                   temp = estaciones[j];
                   estaciones[j] = estaciones[j+1];
                   estaciones[j+1] = temp;
                }   
            }            
        }
    }
    
    public static Estacion[] consultarEstacionesMasUsadas(Estacion[] estaciones){
        // 1) Oredenar la lista de estaciones
        burbuja(estaciones);
        Estacion[] estacionesMasUsadas = { estaciones[0], estaciones[1], estaciones[2] };
        return estacionesMasUsadas;
    }
    
    public HashMap<String, Integer> getBalanceBicicletas(Bicicleta[] bicicletas){
        HashMap<String, Integer> diccionario = new HashMap<String, Integer>();

        int contPre = 0, contSta = 0;
        for (Bicicleta bicicleta : bicicletas) {
            if (bicicleta.getModelo().equals("Premium")) {
                contPre += 1;
            } else if (bicicleta.getModelo().equals("Standard")) {
                contSta += 1;
            }
        }
        // HashMap metodo .put agrega valores al diccionario
        diccionario.put("Standard",contSta);
        diccionario.put("Premium",contPre);
        System.out.println("********************************");
        System.out.println("Datos del diccionario: "+ diccionario);
        return diccionario;
    }

}

