function calculatePriceOfTicket (typeOfDay, agePerson){
    let promotion;

    if (agePerson >= 0 && agePerson <= 18) {
        if (typeOfDay === 'Weekday') {
            promotion = 12;
        }else if (typeOfDay === 'Weekend') {
            promotion = 15;
        }else{
            promotion = 5;
        }
    }else if (agePerson >= 19 && agePerson <= 64) {
        if (typeOfDay === 'Weekday') {
            promotion = 18;
        }else if (typeOfDay === 'Weekend') {
            promotion = 20;
        }else{
            promotion = 12;
        }
    }else if (agePerson >= 65 && agePerson <= 122) {
        if (typeOfDay === 'Weekday') {
            promotion = 12;
        }else if (typeOfDay === 'Weekend') {
            promotion = 15;
        }else{
            promotion = 10;
        }
    }else{
        console.log('Error!');
        return;
    }

    console.log(`${promotion}$`);
}

calculatePriceOfTicket('Holiday', 15);