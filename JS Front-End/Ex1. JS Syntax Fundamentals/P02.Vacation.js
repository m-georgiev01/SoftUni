function calculateTotalPrice(countPeople, typeOfTheGroup, dayOfTheWeek){
    let pricePerTicket = 0;
    let total = 0;
    
    switch (typeOfTheGroup) {
        case 'Students':
            switch (dayOfTheWeek) {
                case 'Friday':
                    pricePerTicket = 8.45;
                    break;
                case 'Saturday':
                    pricePerTicket = 9.8;
                    break;
                case 'Sunday':
                    pricePerTicket = 10.46;
                    break;
            }

            total = countPeople * pricePerTicket;
        break;

        case 'Business':
            switch (dayOfTheWeek) {
                case 'Friday':
                    pricePerTicket = 10.9;
                    break;
                case 'Saturday':
                    pricePerTicket = 15.6;
                    break;
                case 'Sunday':
                    pricePerTicket = 16;
                    break;
            }
            
            total = countPeople * pricePerTicket;
        break;

        case 'Regular':
            switch (dayOfTheWeek) {
                case 'Friday':
                    pricePerTicket = 15;
                    break;
                case 'Saturday':
                    pricePerTicket = 20;
                    break;
                case 'Sunday':
                    pricePerTicket = 22.5;
                    break;
            }

            total = countPeople * pricePerTicket;
        break;
    }

    //discounts
    switch (typeOfTheGroup) {
        case 'Students':
            if (countPeople >= 30) {
                total *= 0.85;
            }
        break;

        case 'Business':
            if (countPeople >= 100) {
                total -= (10 * pricePerTicket);
            }
        break;
        
        case 'Regular':
            if (countPeople >= 10 && countPeople <= 20) {
                total *= 0.95;
            }
        break;
    }

    console.log(`Total price: ${total.toFixed(2)}`);
}