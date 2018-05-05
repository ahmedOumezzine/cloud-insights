<?php 
require 'connect/database.php';
require 'class/users.php';


 error_reporting(0);

$users 		= new Users($db);
if ($users->logged_in() === true)  {
	$user_id 	= $_SESSION['id'];
}

