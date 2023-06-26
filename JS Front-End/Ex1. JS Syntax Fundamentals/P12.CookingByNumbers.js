function cookByNumbers(number, ...operations){
    let sum = Number(number);

    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case 'chop':
                sum /= 2;
                break;
             case 'dice':
                sum = Math.sqrt(sum);
                break;
             case 'spice':
                sum += 1;
                break;
             case 'bake':
                sum *= 3;
                break;
            case 'fillet':
                sum -= sum * 0.2;
                break;
        }
        
        console.log(sum);
    }
}

cookByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet')