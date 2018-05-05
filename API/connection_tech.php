<?php
require './core/init.php';
if (empty($_POST) === false) {
	$username = trim($_POST['username']);
	$password = trim($_POST['password']);
			if (empty($username) === true || empty($password) === true) {
										$arr = array('erreur' => 3, 'message' => "Désolé, mais nous avons besoin de votre nom d'utilisateur et mot de passe.");
										echo json_encode($arr);
			} 
			else
										if ($users->user_exists($username) === false) {
											$arr = array('erreur' => 2, 'message' => "Désolé que le nom d'utilisateur n'existe pas.");
											echo json_encode($arr);
										}  else { 
										
										$login = $users->login($username, $password);
										if ($login === false) {
												$arr = array('erreur' => 1, 'message' => "Désolé, ce nom d'utilisateur / mot de passe est invalide");
												echo json_encode($arr);
										}else {
											$arr = array('erreur' => 0, 'message' => "Welcome ");
											echo json_encode($arr);
		}
	}
} 
?>