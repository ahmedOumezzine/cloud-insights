<?php
	require '../core/init.php'; 
	
	if (empty($_POST) === false) {
	
	$id = $_POST['id'];
	$mdp_crypt = $_POST['code'];
	$UUIDMachine = $_POST['UUIDMachine'];
	$libelleComposant = $_POST['libelleComposant'];

	    if (empty($id) === true ||empty($mdp_crypt) === true || empty($UUIDMachine) === true || empty($libelleComposant) === true) {
			$arr = array('erreur' => 3, 'message' => "Désolé, mais nous avons besoin de votre  UUIDMachine et libelleComposant.");
			echo json_encode($arr);
			} 
		else
			$login=$users->code_client($id,$mdp_crypt);
		if($login==  false)
		{
				$IDCompsant=$users->Composant_exists($UUIDMachine, $libelleComposant);
				if ($IDCompsant === false) {
						$login = $users->Composant($UUIDMachine, $libelleComposant);
						if ($login === false) {
								$arr = array('erreur' => 2, 'message' => "Désolé,insert UUIDMachine et libelleComposant n'est pas valide");
								echo json_encode($arr);
						}else{
							    $IDCompsant=$users->Composant_exists($UUIDMachine, $libelleComposant);
								$arr = array('erreur' => 0, 'message' => $IDCompsant);
								echo json_encode($arr);
						}
				}  else {
						$arr = array('erreur' => 1, 'message' => $IDCompsant);
						echo json_encode($arr);
						return true;
				}
		}
		else{
			$arr = array('erreur' => 4, 'message' => $login);
			echo json_encode($arr);
		}
	}
?>