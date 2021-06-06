const validateUser = (user) => {
    const { Password, Phone, Email } = user;
    const invalidFields = []
    if (!Password) {
        invalidFields.push("Password")
    }
    if (!Phone) {
        invalidFields.push("phone")

    }
    if (!Email) {
        invalidFields.push("mail")
    }
    return invalidFields;
}
