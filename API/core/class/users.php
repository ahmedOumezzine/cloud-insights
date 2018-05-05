<?php 
class Users{
 	
	private $db;
	private $id;

		public function logged_in () {
		return(isset($_SESSION['id'])) ? true : false;
	}
	public function __construct($database) {
	    $this->db = $database;
	}
//********************************************** technicien  *************************************/	
	// vérifie s'il user de techicien exist ou nn ?
	public function user_exists($username) {
		$query = $this->db->prepare("SELECT COUNT(`id`) FROM `users` WHERE `username`= ?");
		$query->bindValue(1, $username);
		try{
			$query->execute();
			$rows = $query->fetchColumn();
			if($rows == 1){
				return true;
			}else{
				return false;
			}
		} catch (PDOException $e){
			die($e->getMessage());
		}
	}
	public function login($username, $password) {
		$query = $this->db->prepare("SELECT `id`, `password` FROM `users` WHERE  `username`= ?");
		$query->bindValue(1, $username);
		try{
			$query->execute();
			$data 				= $query->fetch();
			$stored_password 	= $data['password']; 
			$id   				= $data['id'];
			
			if($password== $stored_password){ 
				return $id;	
			}else{
				return false;	
			}
		}catch(PDOException $e){
			die($e->getMessage());
		}
	}

	
	//********************************************** client   *************************************/	

	// vérifier s'il Client exist ou nn dans BDD 
	public function client_exists($Id) {
		$query = $this->db->prepare("SELECT COUNT(`IDClient`) FROM `client` WHERE `IDClient`= ?");
		$query->bindValue(1, $Id);
		try{
			$query->execute();
			$rows = $query->fetchColumn();
			if($rows == 1){
				return true;
			}else{
				return false;
			}
		} catch (PDOException $e){
			die($e->getMessage());
		}
	}
	
	// vérifier s'il authentification vrai ou nn ??
	public function client($Id,$login, $password) {
		$query = $this->db->prepare("SELECT `login`, `mdp` FROM `client` WHERE `IDClient`= ?");
		$query->bindValue(1,$Id);
		try{
			$query->execute();
			$data 			= $query->fetch();
			$stored_Login 	= $data['login']; 
			$stored_password= $data['mdp'];
			
			if($password== $stored_password || $login== $stored_Login){ 
			$mdp_crypt=$this->crypt($Id);
			return $mdp_crypt;	
			}else{
				return false;	
			}
		}catch(PDOException $e){
			die($e->getMessage());
		}
	}
	
        function crypt($id) {
		$mdp = $this->random(8);
		$mdp_crypt = hash('sha512', $mdp);
		$query = $this->db->prepare("UPDATE `client` SET `code`=? WHERE `IDClient`=?");
		$query->bindValue(1, $mdp_crypt);
		$query->bindValue(2, $id);
		$query->execute();
		return $mdp_crypt;
		}

		function random($car) {
		$string = "";
		$chaine = "ABCDEFGHIJQLMNOPQRSTUVWXYZabcdefghijqlmnopqrstuvwxyz0123456789";
		srand((double)microtime()*1000000);
		for($i=0; $i<$car; $i++) {
			$string .= $chaine[rand()%strlen($chaine)];
		}
		return $string;
		}
		
		
		
		
		
		public function code_client($Id,$mdp_crypt) {
		$query = $this->db->prepare("SELECT * FROM `client` WHERE `IDClient`= ?");
		$query->bindValue(1, $Id);

		try{
			$query->execute();
			$data 	= $query->fetch();
			$login  = $data['code'];
			if($mdp_crypt== $login){ 
 			return true;	
			}else{
				return false;	
			}
		}catch(PDOException $e){
			die($e->getMessage());
		}
		}
	
	
	//********************************************** Composant  *************************************/	

// vérifie s'il composant exists ou nn ??
	public function Composant_exists($UUIDMachine,$libelleComposant) {
		$query = $this->db->prepare("SELECT COUNT(`IDCompsant`) FROM `composant` WHERE  `UUIDMachine`= ? AND `libelleComposant`=?");
		$query->bindValue(1, $UUIDMachine);
		$query->bindValue(2,$libelleComposant);
		try{
			$query->execute();
			$data = $query->fetchColumn();
			if($data == 1){
				return $data['IDCompsant'];
			}else{
				return false;
			}
		} catch (PDOException $e){
			die($e->getMessage());
		}
	}

		// Insertion les values de table  Composant
	public function Composant($UUIDMachine, $libelleComposant) {
		$query = $this->db->prepare("INSERT INTO `composant`( `UUIDMachine`, `libelleComposant`) VALUES (?,?)");
		$query->bindValue(1,$UUIDMachine);
		$query->bindValue(2,$libelleComposant);
		try{
			$query->execute();
			if($query){
				return 	true;
			}else{
				return false;	
			}
		}catch(PDOException $e){
			die($e->getMessage());
		}
	}
	
		//********************************************** Propreite Composant  *************************************/	

	// Insertion les values de table Propreite Composant
		public function insertion($IDCompsant,$ProprieteComposant,$valeurProprieteComposant,$ipProprieteComposant) {
		$query = $this->db->prepare("INSERT INTO `proprietecomposant`( `IDCompsant`,`ProprieteComposant`, `valeurProprieteComposant`, `ipProprieteComposant`, `date`) VALUES (?,?,?,?,NOW())");
		$query->bindValue(1, $IDCompsant);
		$query->bindValue(2, $ProprieteComposant);
		$query->bindValue(3, $valeurProprieteComposant);
		$query->bindValue(4, $ipProprieteComposant);

		try{
			$query->execute();
			
			if($query){ // using the verify method to compare the password with the stored hashed password.
				return true;
			}else{
				return false;	
			}
			
		}catch(PDOException $e){
			die($e->getMessage());
		}
	}
	

	}