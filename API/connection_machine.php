<?php
require '/core/init.php';
if (empty($_POST) === false) {
	$id = trim($_POST['ID']);
	$username = trim($_POST['Login']);
	$password = trim($_POST['password']);

			if (empty($id) === true ||empty($username) === true || empty($password) === true) {
										$arr = array('erreur' => 3, 'message' => "Sorry, but we need your username and password.");
										echo json_encode($arr);
			} 
			else
										if ($users->client_exists($id) === false) {
											$arr = array('erreur' => 2, 'message' => "Sorry that username doesn\'t exists.");
											echo json_encode($arr);
										}  else { 
										
										$login = $users->client($id,$username, $password);
										if ($login === false) {
												$arr = array('erreur' => 1, 'message' => "Sorry, that username/password is invalid");
												echo json_encode($arr);
										}else {
											$arr = array('erreur' => 0, 'message' => $login);
											echo json_encode($arr);
								
								
		}
	}
} 

?>