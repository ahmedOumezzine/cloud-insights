<?php require '../core/init.php';
	
		if (empty($_POST) === false) {
		$id = $_POST['id'];
		$mdp_crypt = $_POST['code'];	
		$IDCompsant = $_POST['IDCompsant'];
		$ProprieteComposant = $_POST['ProprieteComposant'];
   		$valeurProprieteComposant = $_POST['valeurProprieteComposant'];
        $ip = $_POST['ipProprieteComposant']; 

		if (empty($id) === true ||empty($mdp_crypt) === true ||empty($IDCompsant) === true ||empty($ProprieteComposant) === true|| empty($ip) === true) {
			$arr = array('erreur' => 1, 'message' => "Désolé, mais nous avons besoin de votre IDCompsant et IDPCC et valeurProprieteComposant et ipProprieteComposant et libelleComposant.");
			echo json_encode($arr);
		}else{
			$login=$users->code_client($id,$mdp_crypt);
				if($login==  false)
					{
						$login = $users->insertion($IDCompsant,$ProprieteComposant,$valeurProprieteComposant,$ip);
						if ($login === false) {
						$arr = array('erreur' => 2, 'message' => "Désolé,insert n'est pas valide");
						echo json_encode($arr);
						}
						else{
						$arr = array('erreur' => 0, 'message' => "Insert est valide");
						echo json_encode($arr);
						}
				   }
				   else{
				   $arr = array('erreur' => 3, 'message' => "Sorry , tu n'est pas connecté");
				  echo json_encode($arr);
				   }
		}
		}
?>