<?php
require '../core/init.php';
if (empty($_POST) === false) {

	$Id = trim($_POST['Id']);
	$mdp_crypt = trim($_POST['mdp_crypt']);

			if (empty($Id) === true || empty($mdp_crypt) === true) {
										$arr = array('erreur' => 0, 'message' => "Sorry, but we need your username and password.");
										echo json_encode($arr);
			} 
			else

										$login = $users->code_client($Id, $mdp_crypt);
										if ($login === false) {
												$arr = array('erreur' => 1, 'message' => "Sorry, that username/password is invalid");
												echo json_encode($arr);
										}else {
											$arr = array('erreur' => 0, 'message' => "connecte");
											echo json_encode($arr);
								
		}
	}
 

?>