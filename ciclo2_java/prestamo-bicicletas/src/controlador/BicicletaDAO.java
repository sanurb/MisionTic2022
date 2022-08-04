package controlador;
import modelo.Bicicleta;
import java.sql.*;
import java.util.ArrayList;
import javax.swing.JComboBox;
import modelo.BdData;

public class BicicletaDAO extends BdData{
    
    public void consultarEstacion(JComboBox bicicleta){

        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "SELECT id_bicicleta, modelo FROM bd_bicicleta";
            Statement stmt = conn.createStatement();
            ResultSet resul = stmt.executeQuery(sql);
            
            while(resul.next()){
                bicicleta.addItem(resul.getString(1) + "-"  + resul.getString(2));
            }
            
            stmt.close();
            resul.close();
           
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
        
    }

    public ArrayList<Bicicleta> mostrarBicicleta(String ubicacion){
        ArrayList bicicletas = new ArrayList<>();
        Bicicleta bicicleta;
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
                String sql = "SELECT b.* FROM \n" +
                             "bd_estacionbicicleta AS eb, bd_estacion AS e, bd_bicicleta AS b \n" +
                             "WHERE (b.id_bicicleta = eb.id_bicicleta) AND (e.id = eb.id_estacion) AND (e.ubicacion = ?)";
               
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, ubicacion);
                
                ResultSet resul = stmt.executeQuery();
                
            while(resul.next()){
                System.out.println("Llegue");
                int id = resul.getInt(1);
                String idBicicleta =  resul.getString(2);
                String modelo =  resul.getString(3);
                String matricula =  resul.getString(4);
                
                bicicleta = new Bicicleta(idBicicleta, modelo, matricula);
                
                bicicletas.add(bicicleta);
                
                System.out.println("Bicicleta: " + bicicleta.getId());
            }
            
            stmt.close();
            resul.close();
            
            return bicicletas;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());            
        }
        return bicicletas;
    }
    
    public String generarID(){
        
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            int id = 0;
            String sql = "SELECT MAX(id) FROM `bd_bicicleta`";
            Statement stmt = conn.createStatement();
            ResultSet resul = stmt.executeQuery(sql);
            while(resul.next()){
                id = resul.getInt(1);
            }
            
            stmt.close();
            resul.close();
            
            return "B"+id;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());            
        }
        
        return "";
    }
    
    public boolean addBicicleta(String idBicleta, String modelo, String matricula){
       
        try (Connection conn = DriverManager.getConnection(getUrl(), getUser(), getPassword())) {
            
            String sql = "INSERT INTO `bd_bicicleta`(`id_bicicleta`, `modelo`, `matricula`) \n" +
                         "VALUES (?,?,?)";
           
            PreparedStatement stmt = conn.prepareStatement(sql);
            
            stmt.setString(1, idBicleta);
            stmt.setString(2, modelo);
            stmt.setString(3, matricula);
            
            stmt.executeUpdate();
            stmt.close();
           
            return true;
            
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());            
        }
        
        return false;
    }

}
