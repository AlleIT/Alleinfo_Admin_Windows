<?php
require_once("../webbadmin/core/Classes/Database.php");

Class ClientAssist extends Database {

	const ACCEPTEDMSG = "accepted";

	public function login() {
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() == 1){
			echo self::ACCEPTEDMSG;
        } else {
           	echo "Inloggningen misslyckades.";
        }
	}

	public function getHome() {
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() == 1){
			$row = $query->fetch(PDO::FETCH_ASSOC);
            echo self::ACCEPTEDMSG . $row['logoPath'] . "," . $row['description'] . "," . $row['socialLink'] . $row['color'];
        } else {
            echo "Felaktiga användaruppgifter.";
        }
	}

	public function setHome() {
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}

		$row = $query->fetch(PDO::FETCH_ASSOC);
		
		$handler = $row['handler'];

		$path = "/var/www/AlleIT/Alleinfo/utskottsbilder".strrchr($row['logoPath'], "/");

		$image = htmlentities(strip_tags($_POST['image']));

		$file = fopen($path, "w");
		fwrite($file, base64_decode($image));
		fclose($file);

		$description = $_POST['description'];
		$socialLink = strip_tags($_POST['socialURL']);
		$color = htmlentities(strip_tags($_POST['color']));

		$query = $this->_link->prepare("UPDATE `accounts` SET `description` = :description, `socialLink` = :sociallink, `color` = :color WHERE `accounts`.`id` =".$row['id']);
                $query->bindParam(":description", $description, PDO::PARAM_STR);
                $query->bindParam(":sociallink", $socialLink, PDO::PARAM_STR);
                $query->bindParam(":color", $color, PDO::PARAM_STR);
                $query->execute();

		$query = $this->_link->prepare("UPDATE `elevkaren_news` SET `color` = :color WHERE `handler` = :handler");
                $query->bindParam(":color", $color, PDO::PARAM_STR);
				$query->bindParam(":handler", $handler, PDO::PARAM_STR);
                $query->execute();

        echo self::ACCEPTEDMSG;
	}
	
	public function setNews() {
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}

		$row = $query->fetch(PDO::FETCH_ASSOC);

		$id = htmlentities(strip_tags($_POST['id']));
		$headline = $_POST['headline'];
		$shortDesc = $_POST['shortDesc'];
		$butUrl = $_POST['butUrl'];
		$description = $_POST['description'];
		$type = $_POST['type'];
		$date = $_POST['pubDate'];
				
		if($id == -1)
		{
			$query = $this->_link->prepare("INSERT INTO `elevkaren_news` (`headline`, `shortInfo`, `description`, `butURL`, `type`, `handler`, `pubDate`) VALUES (:headline, :shortDesc, :description, :butUrl, :type, :handler, :date);");
            $query->bindParam(":headline", $headline, PDO::PARAM_STR);
            $query->bindParam(":shortDesc", $shortDesc, PDO::PARAM_STR);
            $query->bindParam(":description", $description, PDO::PARAM_STR);
            $query->bindParam(":butUrl", $butUrl, PDO::PARAM_STR);
            $query->bindParam(":type", $type, PDO::PARAM_STR);
            $query->bindParam(":handler", $row['handler'], PDO::PARAM_STR);
            $query->bindParam(":date", $date, PDO::PARAM_STR);
            $query->execute();

            echo self::ACCEPTEDMSG;
		} else {
			$query = $this->_link->prepare("UPDATE `elevkaren_news` SET  `headline` =  :headline, `shortInfo` =  :shortDesc, `description` =  :description, `butURL` =  :butUrl, `type` =  :type, `handler` =  :handler WHERE  `elevkaren_news`.`id` = :id;");
            $query->bindParam(":headline", $headline, PDO::PARAM_STR);
            $query->bindParam(":shortDesc", $shortDesc, PDO::PARAM_STR);
            $query->bindParam(":description", $description, PDO::PARAM_STR);
            $query->bindParam(":butUrl", $butUrl, PDO::PARAM_STR);
            $query->bindParam(":type", $type, PDO::PARAM_STR);
            $query->bindParam(":handler", $row['handler'], PDO::PARAM_STR);
            $query->bindParam(":id", $id, PDO::PARAM_STR);
            $query->execute();
			
            echo self::ACCEPTEDMSG;
		}
	}
	
	public function getAllNews()
	{
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}

		$userDetails = $query->fetch(PDO::FETCH_ASSOC);
		
       	$query = $this->_link->prepare("SELECT * FROM `elevkaren_news` WHERE handler = :handler ORDER BY `id` DESC");
       	$query->bindParam(":handler", $userDetails['handler'], PDO::PARAM_STR);
       	$query->execute();
	
		$rows = array();
	
		if($query->execute())
		{			
			while($row = $query->fetch(PDO::FETCH_ASSOC))
			{
				$rows[] = $row;
			}
		}
		echo self::ACCEPTEDMSG . json_encode($rows);
	}
	
	public function getNewsCount()
	{
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}

		$userDetails = $query->fetch(PDO::FETCH_ASSOC);
		
       	$query = $this->_link->prepare("SELECT * FROM `elevkaren_news` WHERE handler = :handler");
       	$query->bindParam(":handler", $userDetails['handler'], PDO::PARAM_STR);
       	$query->execute();
		
		echo self::ACCEPTEDMSG . $query->rowCount();
	}
	
	public function removeNews()
	{
		$username = htmlentities(strip_tags($_POST['username']));
        $password = htmlentities(hash("SHA512", $_POST['password']));
		
       	// check if user exist
       	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
       	$query->bindParam(":username", $username, PDO::PARAM_STR);
       	$query->bindParam(":password", $password, PDO::PARAM_STR);
       	$query->execute();
		
       	if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}
		
		$id = htmlentities(strip_tags($_POST['id']));
		
       	$query = $this->_link->prepare("DELETE FROM `elevkaren_news` WHERE `elevkaren_news`.`id` = :id");
       	$query->bindParam(":id", $id, PDO::PARAM_STR);
       	$query->execute();
		
		echo self::ACCEPTEDMSG;
	
	}
}

?>
